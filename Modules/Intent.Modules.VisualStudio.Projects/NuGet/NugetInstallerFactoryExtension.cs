using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Intent.Engine;
using Intent.Eventing;
using Intent.Modules.Common;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Constants;
using Intent.Modules.VisualStudio.Projects.NuGet.HelperTypes;
using Intent.Modules.VisualStudio.Projects.NuGet.SchemeProcessors;
using Intent.Plugins.FactoryExtensions;
using Intent.Utils;
using NuGet.Versioning;

namespace Intent.Modules.VisualStudio.Projects.NuGet
{
    public class NugetInstallerFactoryExtension : FactoryExtensionBase, IExecutionLifeCycle
    {
        private readonly ISoftwareFactoryEventDispatcher _eventDispatcher;
        private readonly IChanges _changeManager;
        public const string Identifier = "Intent.VisualStudio.NuGet.Installer";
        private const string SettingKeyForConsolidatePackageVersions = "Consolidate Package Versions"; // Must match the config entry in the .imodspec
        private const string SettingKeyForWarnOnMultipleVersionsOfSamePackage = "Warn On Multiple Versions of Same Package"; // Must match the config entry in the .imodspec
        private bool _settingConsolidatePackageVersions;
        private bool _settingWarnOnMultipleVersionsOfSamePackage;
        private static readonly IDictionary<NuGetScheme, INuGetSchemeProcessor> NuGetProjectSchemeProcessors;

        static NugetInstallerFactoryExtension()
        {
            NuGetProjectSchemeProcessors = new Dictionary<NuGetScheme, INuGetSchemeProcessor>
            {
                { NuGetScheme.Lean, new LeanSchemeProcessor() },
                { NuGetScheme.Unsupported, new UnsupportedSchemeProcessor() },
                { NuGetScheme.VerboseWithPackageReference, new VerboseWithPackageReferencesSchemeProcessor() },
                { NuGetScheme.VerboseWithPackagesDotConfig, new VerboseWithPackagesDotConfigSchemeProcessor() }
            };
        }

        public NugetInstallerFactoryExtension(ISoftwareFactoryEventDispatcher eventDispatcher, IChanges changeManager)
        {
            _eventDispatcher = eventDispatcher;
            _changeManager = changeManager;
        }

        public override int Order => 200;

        public override string Id => Identifier;

        public override void Configure(IDictionary<string, string> settings)
        {
            settings.SetIfSupplied(
                name: SettingKeyForConsolidatePackageVersions,
                setSetting: parsedValue => _settingConsolidatePackageVersions = parsedValue,
                convert: rawValue => true.ToString().Equals(rawValue, StringComparison.OrdinalIgnoreCase));
            settings.SetIfSupplied(
                name: SettingKeyForWarnOnMultipleVersionsOfSamePackage,
                setSetting: parsedValue => _settingWarnOnMultipleVersionsOfSamePackage = parsedValue,
                convert: rawValue => true.ToString().Equals(rawValue, StringComparison.OrdinalIgnoreCase));

            base.Configure(settings);
        }

        public void OnStep(IApplication application, string step)
        {
            if (step != ExecutionLifeCycleSteps.AfterTemplateExecution)
            {
                return;
            }

            var tracing = new TracingWithPrefix(Logging.Log, "NuGet - ");

            tracing.Info("Start processing packages");

            // Call a separate method to do the actual execution which is internally accessible and more easily unit testable.
            Execute(
                applicationProjects: application.Projects,
                tracing: tracing,
                saveProjectDelegate: SaveProject,
                loadProjectDelegate: LoadProject);

            tracing.Info("Package processing complete");
        }

        private string LoadProject(IProject project)
        {
            var change = _changeManager.FindChange(project.ProjectFile());

            return change != null
                ? change.Content
                : File.ReadAllText(Path.GetFullPath(project.ProjectFile()));
        }

        private void SaveProject(string filePath, string content)
        {
            var change = _changeManager.FindChange(filePath);

            // Normalize the content of both by parsing with no whitespace and calling .ToString()
            var targetContent = XDocument.Parse(content).ToString();
            var existingContent = change != null
                ? XDocument.Parse(change.Content).ToString()
                : XDocument.Load(filePath).ToString();

            if (existingContent == targetContent)
            {
                return;
            }

            if (change != null)
            {
                change.ChangeContent(content);
                return;
            }

            _eventDispatcher.Publish(new SoftwareFactoryEvent(SoftwareFactoryEvents.OverwriteFileCommand, new Dictionary<string, string>
            {
                { "FullFileName", filePath },
                { "Content", content },
            }));
        }

        /// <param name="saveProjectDelegate">T1 = path, T2 = content</param>
        internal void Execute(
            IEnumerable<IProject> applicationProjects,
            ITracing tracing,
            Action<string, string> saveProjectDelegate,
            Func<IProject, string> loadProjectDelegate)
        {
            string report;
            var (projectPackages, highestVersions) = DeterminePackages(applicationProjects, loadProjectDelegate);

            if (_settingConsolidatePackageVersions &&
                !string.IsNullOrWhiteSpace(report = GetPackagesWithMultipleVersionsReport(projectPackages)))
            {
                tracing.Info(
                    "Multiple versions exist for one or more NuGet packages within the solution. Intent will now automatically " +
                           "upgrade any lower versions to the highest installed version within the solution. To disable this behaviour " +
                           $"change the 'Consolidate Package Versions' option in Intent in the {Identifier} module configuration." +
                           $"{Environment.NewLine}" +
                           $"{Environment.NewLine}" +
                           $"{report}");

                ConsolidatePackageVersions(projectPackages, highestVersions);
            }

            foreach (var projectPackage in projectPackages)
            {
                if (!projectPackage.RequestedPackages.Any())
                {
                    continue;
                }

                var updatedProjectContent = projectPackage.Processor.InstallPackages(
                    projectContent: projectPackage.Content,
                    requestedPackages: projectPackage.RequestedPackages,
                    installedPackages: projectPackage.InstalledPackages,
                    projectName: projectPackage.Name,
                    tracing: tracing);
                saveProjectDelegate(projectPackage.FilePath, updatedProjectContent);
            }

            if (_settingWarnOnMultipleVersionsOfSamePackage &&
                !_settingConsolidatePackageVersions &&
                !string.IsNullOrWhiteSpace(report = GetPackagesWithMultipleVersionsReport(projectPackages)))
            {
                tracing.Warning(
                    "Multiple versions exist for one or more NuGet packages within the solution. You should consider " +
                           "consolidating these package versions within Visual Studio or alternatively enable the 'Consolidate " +
                           $"Package Versions' option in Intent in the {Identifier} module configuration." +
                           $"{Environment.NewLine}" +
                           $"{Environment.NewLine}" +
                           $"{report}");
            }

        }

        /// <summary>
        /// Internal so available to unit tests
        /// </summary>
        internal static (IReadOnlyCollection<NuGetProject> Projects, Dictionary<string, NuGetVersion> HighestVersions) DeterminePackages(IEnumerable<IProject> applicationProjects, Func<IProject, string> loadDelegate)
        {
            var projects = new List<NuGetProject>();
            var highestVersions = new Dictionary<string, NuGetVersion>();

            foreach (var project in applicationProjects.OrderBy(x => x.Name))
            {
                string projectContent = null;
                var document = project.ProjectFile() != null
                    ? XDocument.Parse(projectContent = loadDelegate(project))
                    : null;

                var projectType = ResolveNuGetScheme(document);
                if (!NuGetProjectSchemeProcessors.TryGetValue(projectType, out var processor)) throw new ArgumentOutOfRangeException(nameof(projectType), $"No scheme registered for type {projectType}.");

                var installedPackages = processor.GetInstalledPackages(project, document);

                foreach (var installedPackage in installedPackages)
                {
                    var packageId = installedPackage.Key;

                    if (!highestVersions.TryGetValue(packageId, out var highestVersion) ||
                        highestVersion < installedPackage.Value.Version)
                    {
                        highestVersions[packageId] = installedPackage.Value.Version;
                    }
                }

                var consolidatedPackages = installedPackages.ToDictionary(x => x.Key, x => x.Value.Clone());
                var requestedPackages = new Dictionary<string, NuGetPackage>();

                foreach (var package in project.NugetPackages())
                {
                    if (!NuGetVersion.TryParse(package.Version, out var semanticVersion))
                    {
                        throw new Exception($"Could not parse '{package.Version}' from Intent metadata for package '{package.Name}' in project '{project.Name}' as a valid Semantic Version 2.0 'version' value.");
                    }

                    if (!highestVersions.TryGetValue(package.Name, out var highestVersion) ||
                        highestVersion < semanticVersion)
                    {
                        highestVersions[package.Name] = highestVersion = semanticVersion;
                    }

                    if (consolidatedPackages.TryGetValue(package.Name, out var consolidatedPackage))
                    {
                        consolidatedPackage.Update(highestVersion, package);
                    }
                    else
                    {
                        consolidatedPackages.Add(package.Name, NuGetPackage.Create(package, highestVersion));
                    }

                    if (requestedPackages.TryGetValue(package.Name, out var requestedPackage))
                    {
                        requestedPackage.Update(highestVersion, package);
                    }
                    else
                    {
                        requestedPackages.Add(package.Name, NuGetPackage.Create(package, highestVersion));
                    }
                }

                projects.Add(new NuGetProject
                {
                    Content = projectContent,
                    RequestedPackages = requestedPackages,
                    InstalledPackages = installedPackages,
                    Name = project.Name,
                    FilePath = project.ProjectFile(),
                    Processor = processor
                });
            }

            return (projects, highestVersions);
        }

        internal static NuGetScheme ResolveNuGetScheme(XNode xNode)
        {
            if (xNode == null)
            {
                return NuGetScheme.Unsupported;
            }

            var (prefix, namespaceManager, namespaceName) = xNode.Document.GetNamespaceManager();
            
            if (xNode.XPathSelectElement("/Project[@Sdk]") != null)
            {
                return NuGetScheme.Lean;
            }

            if (xNode.XPathSelectElement($"/{prefix}:Project/{prefix}:ItemGroup/{prefix}:None[@Include='packages.config']", namespaceManager) != null)
            {
                return NuGetScheme.VerboseWithPackagesDotConfig;
            }

            if (xNode.XPathSelectElement($"/{prefix}:Project", namespaceManager) != null)
            {
                // Even if there is no PackageReference element, so long as there is no packages.config, then we are free to to use
                // PackageReferences going forward. In the event there is PackageReference element, then we are of course already
                // using the PackageReference scheme.
                return NuGetScheme.VerboseWithPackageReference;
            }

            return NuGetScheme.Unsupported;
        }

        private static void ConsolidatePackageVersions(IReadOnlyCollection<NuGetProject> projectPackages, IDictionary<string, NuGetVersion> highestVersions)
        {
            foreach (var highestVersion in highestVersions)
            {
                foreach (var projectPackage in projectPackages)
                {
                    if (projectPackage.RequestedPackages.TryGetValue(highestVersion.Key, out var requestedPackage) &&
                        requestedPackage.Version < highestVersion.Value)
                    {
                        requestedPackage.Version = highestVersion.Value;
                    }

                    if (projectPackage.InstalledPackages.TryGetValue(highestVersion.Key, out var installedPackage) &&
                        installedPackage.Version < highestVersion.Value)
                    {
                        projectPackage.RequestedPackages.Add(highestVersion.Key, installedPackage.Clone(highestVersion.Value));
                    }
                }
            }
        }

        private static string GetPackagesWithMultipleVersionsReport(IEnumerable<NuGetProject> nuGetProjects)
        {
            var resolvedProjects = nuGetProjects
                .Select(x => new
                {
                    ConsolidatedPackageVersions = x.GetConsolidatedPackages(),
                    ProjectName = x.Name
                })
                .ToArray();

            var packagesWithMultipleVersions = resolvedProjects
                .SelectMany(x => x.ConsolidatedPackageVersions)
                .GroupBy(x => x.Key, x => x.Value.Version)
                .Where(x => x.Distinct().Count() > 1)
                .Select(x => x.Key)
                .ToArray();

            if (!packagesWithMultipleVersions.Any())
            {
                return null;
            }

            return packagesWithMultipleVersions
                .Select(packageId => new
                {
                    PackageId = packageId,
                    VersionReport = resolvedProjects
                        .Where(x => x.ConsolidatedPackageVersions.ContainsKey(packageId))
                        .Select(x => new
                        {
                            x.ProjectName,
                            x.ConsolidatedPackageVersions[packageId].Version
                        })
                        .OrderByDescending(x => x.Version)
                        .ThenBy(x => x.ProjectName)
                        .Select(x => $"    Version {x.Version} in '{x.ProjectName}'")
                        .Aggregate((x, y) => x + Environment.NewLine + y)
                })
                .Select(x => $"{x.PackageId} has the following versions installed:{Environment.NewLine}{x.VersionReport}")
                .Aggregate((x, y) => x + Environment.NewLine + y);
        }
    }
}

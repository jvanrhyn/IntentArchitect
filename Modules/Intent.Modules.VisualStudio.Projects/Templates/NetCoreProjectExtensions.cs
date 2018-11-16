﻿using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.VisualStudio;

namespace Intent.Modules.VisualStudio.Projects.Templates
{
    public static class NetCoreProjectExtensions
    {
        public static void InstallNugetPackages(this IProject project, XDocument doc)
        {
            var nugetPackages = project
                .NugetPackages()
                .Distinct()
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, x => x);

            if (!nugetPackages.Any())
            {
                return;
            }

            var packageReferenceItemGroup = doc.XPathSelectElement("Project/ItemGroup[PackageReference]");
            if (packageReferenceItemGroup == null)
            {
                packageReferenceItemGroup = new XElement("ItemGroup");
                doc.XPathSelectElement("Project").Add(packageReferenceItemGroup);
            }

            foreach (var addFileBehaviour in nugetPackages)
            {
                var latestVersion = addFileBehaviour.Value.OrderByDescending(x => x.Version).First().Version;
                var existingReference =
                    packageReferenceItemGroup.XPathSelectElement($"PackageReference[@Include='{addFileBehaviour.Key}']");

                if (existingReference == null)
                {
                    //tracing.Info($"{TracingOutputPrefix}Installing {addFileBehaviour.Key} {latestVersion} into project {netCoreProject.Name}");

                    packageReferenceItemGroup.Add(new XElement("PackageReference",
                        new XAttribute("Include", addFileBehaviour.Key),
                        new XAttribute("Version", latestVersion)));
                }
            }
        }
    }
}
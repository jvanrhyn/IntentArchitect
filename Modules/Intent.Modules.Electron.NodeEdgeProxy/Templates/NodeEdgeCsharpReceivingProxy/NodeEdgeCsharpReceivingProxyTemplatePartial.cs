﻿using Intent.Modelers.Services.Api;
using Intent.Modules.Application.Contracts.Templates.DTO;
using Intent.Modules.Application.Contracts.Templates.ServiceContract;
using Intent.Modules.Unity.Templates.UnityConfig;
using Intent.Engine;
using Intent.Templates;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Application.Contracts;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.SoftwareFactory.Templates;

namespace Intent.Modules.Electron.NodeEdgeProxy.Templates.NodeEdgeCsharpReceivingProxy
{
    partial class NodeEdgeCsharpReceivingProxyTemplate : IntentRoslynProjectItemTemplateBase<IServiceModel>, ITemplate, IPostTemplateCreation, IHasTemplateDependencies, IHasNugetDependencies
    {
        public const string Identifier = "Intent.Electron.NodeEdgeProxy.CsharpReceivingProxy";

        public NodeEdgeCsharpReceivingProxyTemplate(IServiceModel model, IProject project)
            : base(Identifier, project, model)
        {
        }

        public void Created()
        {
            Types.AddClassTypeSource(CSharpTypeSource.InProject(Project, DTOTemplate.IDENTIFIER, "List<{0}>"));
        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Identifier, "1.0"));
        }

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: $"{Model.Name}NodeEdgeProxy",
                fileExtension: "cs",
                defaultLocationInProject: @"NodeEdgeProxies\Generated",
                className: $"{Model.Name}NodeEdgeProxy",
                @namespace: "${Project.ProjectName}");
        }

        public IEnumerable<ITemplateDependency> GetTemplateDependencies()
        {
            return new[]
            {
                TemplateDependency.OnTemplate(UnityConfigTemplate.Identifier),
                TemplateDependency.OnModel(ServiceContractTemplate.IDENTIFIER, Model),
                TemplateDependency.OnTemplate(DTOTemplate.IDENTIFIER)
            };
        }

        public override IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return new[]
            {
                NugetPackages.NewtonsoftJson,
            }
            .Union(base.GetNugetDependencies())
            .ToArray();
        }

        private string GetOperationCallParameters(IOperation o)
        {
            if (!o.Parameters.Any())
            {
                return string.Empty;
            }

            return o.Parameters
                .Select((x, i) => $"Deserialize<{GetTypeName(x.Type)}>(methodParameters[{i}])")
                .Aggregate((x, y) => x + ", " + y);
        }

        private string GetTypeName(ITypeReference typeInfo)
        {
            //var result = NormalizeNamespace(typeInfo.GetQualifiedName(this));
            //if (typeInfo.IsCollection)
            //{
            //    result = "List<" + result + ">";
            //}
            //return result;
            return Types.Get(typeInfo, "List<{0}>");
        }
    }
}

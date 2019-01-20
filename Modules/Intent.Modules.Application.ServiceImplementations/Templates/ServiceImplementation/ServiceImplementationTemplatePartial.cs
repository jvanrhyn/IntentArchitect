﻿using System.Collections.Generic;
using System.Linq;
using Intent.MetaModel.Common;
using Intent.MetaModel.Service;
using Intent.Modules.Application.Contracts;
using Intent.Modules.Application.Contracts.Templates.ServiceContract;
using Intent.Modules.Common;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Constants;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;

namespace Intent.Modules.Application.ServiceImplementations.Templates.ServiceImplementation
{
    partial class ServiceImplementationTemplate : IntentRoslynProjectItemTemplateBase<IServiceModel>, ITemplate, IHasTemplateDependencies, IBeforeTemplateExecutionHook, IHasDecorators<ServiceImplementationDecoratorBase>
    {
        private IEnumerable<ServiceImplementationDecoratorBase> _decorators;

        public const string Identifier = "Intent.Application.ServiceImplementations";
        public ServiceImplementationTemplate(IProject project, IServiceModel model)
            : base(Identifier, project, model)
        {
        }

        public IEnumerable<ITemplateDependancy> GetTemplateDependencies()
        {
            return new[]
            {
                TemplateDependancy.OnModel<ServiceModel>(ServiceContractTemplate.IDENTIFIER, x => x.Id == Model.Id)
            };
        }

        public IEnumerable<ServiceImplementationDecoratorBase> GetDecorators()
        {
            if (_decorators == null)
            {
                _decorators = Project.ResolveDecorators(this);
            }
            return _decorators;
        }

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Id, "1.0"));
        }

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "${Model.Name}",
                fileExtension: "cs",
                defaultLocationInProject: "ServiceImplementation",
                className: "${Model.Name}",
                @namespace: "${Project.ProjectName}.ServiceImplementation"

                );
        }

        public void BeforeTemplateExecution()
        {
            Project.Application.EventDispatcher.Publish(ContainerRegistrationEvent.EventId, new Dictionary<string, string>()
            {
                { "InterfaceType", GetServiceInterfaceName()},
                { "ConcreteType", $"{Namespace}.{ClassName}" },
                { "InterfaceTypeTemplateId", ServiceContractTemplate.IDENTIFIER },
                { "ConcreteTypeTemplateId", Identifier }
            });
        }

        private string GetOperationDefinitionParameters(IOperationModel o)
        {
            if (!o.Parameters.Any())
            {
                return "";
            }
            return o.Parameters.Select(x => $"{GetTypeName(x.TypeReference)} {x.Name}").Aggregate((x, y) => x + ", " + y);
        }

        private string GetOperationCallParameters(IOperationModel o)
        {
            if (!o.Parameters.Any())
            {
                return "";
            }
            return o.Parameters.Select(x => $"{x.Name}").Aggregate((x, y) => x + ", " + y);
        }

        private string GetOperationReturnType(IOperationModel o)
        {
            if (o.ReturnType == null)
            {
                return o.IsAsync() ? "async Task" : "void";
            }
            return o.IsAsync() ? $"async Task<{GetTypeName(o.ReturnType.TypeReference)}>" : GetTypeName(o.ReturnType.TypeReference);
        }

        public string GetServiceInterfaceName()
        {
            var serviceContractTemplate = Project.Application.FindTemplateInstance<IHasClassDetails>(TemplateDependancy.OnModel<ServiceModel>(ServiceContractTemplate.IDENTIFIER, x => x.Id == Model.Id));
            return $"{serviceContractTemplate.Namespace}.{serviceContractTemplate.ClassName}";
        }

        private string GetTypeName(ITypeReference typeInfo)
        {
            var result = NormalizeNamespace(typeInfo.GetQualifiedName(this));
            if (typeInfo.IsCollection)
            {
                result = "List<" + result + ">";
            }
            return result;
        }

        private string GetConstructorDependencies()
        {
            // DJVV - TODO:
            // Convention module:
            // 1. Scan MetadataManger in the same way the Repo Interface register does it
            // 2. This will mean that you will need the module settings like the Repo Interface module (filtering and TemplateID)
            // 3. Then you can return those interface FQDNs with parameter names for the Constructor dependencies
            // 4. Determining usings are dependent on the current service implementation
            // 5. Now you can match up domain classes with services and populate the relevant implementations

            return string.Empty;
        }

        private string GetDecoratedImplementation(IOperationModel operation)
        {
            return string.Empty;
        }
    }
}

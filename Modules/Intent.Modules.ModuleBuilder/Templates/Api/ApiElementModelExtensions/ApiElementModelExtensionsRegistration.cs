using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.Modules.ModuleBuilder.Api;
using Intent.Modules.ModuleBuilder.Templates.Api.ApiElementModelExtensions;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.FilePerModel", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Templates.Api.ApiElementModelExtensions
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class ApiElementModelExtensionsRegistration : ModelTemplateRegistrationBase<ExtensionModel>
    {
        private readonly IMetadataManager _metadataManager;
        private IEnumerable<IStereotypeDefinition> _stereotypeDefinitions;

        public ApiElementModelExtensionsRegistration(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public override string TemplateId => ApiElementModelExtensions.TemplateId;

        public override ITemplate CreateTemplateInstance(IProject project, ExtensionModel model)
        {
            return new ApiElementModelExtensions(project, model);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override IEnumerable<ExtensionModel> GetModels(IApplication application)
        {
            _stereotypeDefinitions = _metadataManager.ModuleBuilder(application).StereotypeDefinitions
                .Where(x => x.TargetMode == StereotypeTargetMode.ElementsOfType);
            var targetTypes = _stereotypeDefinitions.SelectMany(x => x.TargetElements).Distinct();
            return targetTypes.Select(x => new ExtensionModel(new ExtensionModelType(x.Name), _stereotypeDefinitions.Where(s => s.TargetElements.Any(t => t.Id.Equals(x.Id, StringComparison.InvariantCultureIgnoreCase))).ToList()));
        }
    }
}
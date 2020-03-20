using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.Modules.ModuleBuilder.Api;
using Intent.Modules.ModuleBuilder.Helpers;
using Intent.Templates;

namespace Intent.Modules.ModuleBuilder.Templates.Registration.SingleFileListModel
{
    public class SingleFileListModelTemplateRegistrationRegistrations : ModelTemplateRegistrationBase<ITemplateRegistration>
    {
        private readonly IMetadataManager _metadataManager;

        public SingleFileListModelTemplateRegistrationRegistrations(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public override string TemplateId => SingleFileListModelTemplateRegistrationTemplate.TemplateId;

        public override ITemplate CreateTemplateInstance(IProject project, ITemplateRegistration model)
        {
            return new SingleFileListModelTemplateRegistrationTemplate(project, model);
        }

        public override IEnumerable<ITemplateRegistration> GetModels(IApplication application)
        {
            return _metadataManager.GetMetadata<IElement>("Module Builder")
                .Where(x => x.ReferencesSingleFile())
                .Select(x => new TemplateRegistration(x))
                .Where(x => x.GetTemplateSettings().ModelType() != null)
                .ToList();
        }
    }
}
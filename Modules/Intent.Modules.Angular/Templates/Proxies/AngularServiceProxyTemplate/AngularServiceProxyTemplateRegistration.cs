using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Services;
using Intent.Modules.Angular.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.FilePerModel", Version = "1.0")]

namespace Intent.Modules.Angular.Templates.Proxies.AngularServiceProxyTemplate
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class AngularServiceProxyTemplateRegistration : ModelTemplateRegistrationBase<IServiceProxyModel>
    {
        private readonly IMetadataManager _metaDataManager;

        public AngularServiceProxyTemplateRegistration(IMetadataManager metaDataManager)
        {
            _metaDataManager = metaDataManager;
        }

        public override string TemplateId => AngularServiceProxyTemplate.TemplateId;

        public override ITemplate CreateTemplateInstance(IProject project, IServiceProxyModel model)
        {
            return new AngularServiceProxyTemplate(project, model);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override IEnumerable<IServiceProxyModel> GetModels(Engine.IApplication application)
        {
            return _metaDataManager.GetModules(application).SelectMany(x => x.ServiceProxies).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiModelInterfaceTemplate", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    public interface ITemplateRegistration : IMetadataModel, IHasStereotypes, IHasFolder
    {
        string Name { get; }
        IModeler GetModeler();
        IModelerModelType GetModelType();
        bool IsSingleFileTemplateRegistration();
        bool IsFilePerModelTemplateRegistration();
        bool IsCustomTemplateRegistration();
    }
}
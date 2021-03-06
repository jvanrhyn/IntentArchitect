using System.Linq;
using Intent.Engine;
using Intent.Modules.Common.Templates;
using Intent.ModuleBuilder.Api;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using System.Collections.Generic;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp;
using Intent.Modules.Common.CSharp.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Templates.Api.ApiElementModel
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class ApiElementModelTemplate : CSharpTemplateBase<ElementSettingsModel>
    {
        public bool HasParentFolder { get; private set; } = false;
        public List<AssociationSettingsModel> AssociationSettings { get; }

        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.ModuleBuilder.Templates.Api.ApiElementModel";

        public ApiElementModelTemplate(IOutputTarget project, ElementSettingsModel model, List<AssociationSettingsModel> associationSettings) : base(TemplateId, project, model)
        {
            AssociationSettings = associationSettings;
            AddTypeSource(CSharpTypeSource.Create(ExecutionContext, ApiElementModelTemplate.TemplateId, collectionFormat: "IEnumerable<{0}>"));
            ExecutionContext.EventDispatcher.Subscribe<NotifyModelHasParentFolderEvent>(@event =>
            {
                if (@event.ModelId == model.Id)
                {
                    HasParentFolder = true;
                }
            });
        }

        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"{Model.ApiModelName}",
                @namespace: Model.ParentModule.ApiNamespace);
        }

        public string BaseType => Model.GetInheritedType() != null
            ? GetTypeName(TemplateId, Model.GetInheritedType().Id, new TemplateDiscoveryOptions() { ThrowIfNotFound = false })
                ?? $"{Model.GetInheritedType().Name.ToCSharpIdentifier()}Model"
            : null;

        public string GetInterfaces()
        {
            var interfaces = new List<string> { "IMetadataModel", "IHasStereotypes", "IHasName" };
            if (!Model.GetTypeReferenceSettings().Mode().IsDisabled() && Model.GetTypeReferenceSettings().Represents().IsReference())
            {
                interfaces.Add("IHasTypeReference");
            }

            if (HasParentFolder)
            {
                interfaces.Add("IHasFolder");
            }

            return string.Join(", ", interfaces);
        }

        private string FormatForCollection(string name, bool asCollection)
        {
            return asCollection ? $"IList<{name}>" : name;
        }

        private string FormatForCollection(AssociationCreationOptionModel option)
        {
            var asCollection = option.GetOptionSettings().AllowMultiple();
            return asCollection ? $"IList<{option.Type.ApiModelName}>" : option.Type.ApiModelName;
        }

        private string GetCreationOptionName(ElementCreationOptionModel option)
        {
            if (option.GetOptionSettings().ApiModelName() != null)
            {
                return option.GetOptionSettings().ApiModelName();
            }
            var name = option.Name.Replace("Add ", "").Replace("New ", "").ToCSharpIdentifier();
            return option.GetOptionSettings().AllowMultiple() ? name.ToPluralName() : name;
        }

        private bool ExistsInBase(ElementCreationOptionModel creationOption)
        {
            return Model.GetInheritedType()?.MenuOptions?.ElementCreations.Any(x => x.Type.Id == creationOption.Type.Id) ??
                   false;
        }

        private bool ExistsInBase(AssociationCreationOptionModel creationOption)
        {
            return Model.GetInheritedType()?.MenuOptions?.AssociationCreations.Any(x => x.Type.Id == creationOption.Type.Id) ??
                   false;
        }

        private bool ExistsInBase(AssociationSettingsModel associationSettings)
        {
            return false;
            //throw new System.NotImplementedException();
        }
    }
}
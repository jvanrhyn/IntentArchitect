using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiModelImplementationTemplate", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    internal class TemplateRegistration : ITemplateRegistration
    {
        public const string SpecializationType = "Template Registration";
        private readonly IElement _element;

        public TemplateRegistration(IElement element)
        {
            if (element.TypeReference == null)
            {
                throw new Exception("Cannot create 'TemplateRegistration'. Element must have a type reference.");
            }
            if (!SpecializationType.Equals(element.TypeReference?.Element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a 'TemplateRegistration' from element that has type-reference with specialization type '{element.TypeReference?.Element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
            Folder = element.ParentElement != null ? new Folder(element.ParentElement) : null;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public IModeler GetModeler()
        {
            return GetModelType()?.Modeler;
        }

        public IModelerModelType GetModelType()
        {
            return this.GetTemplateSettings()?.ModelType() != null ? new ModelerModelType(this.GetTemplateSettings().ModelType()) : null;
        }

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public IFolder Folder { get; }

        public bool IsSingleFileTemplateRegistration()
        {
            return _element.ReferencesSingleFile();
        }

        public bool IsFilePerModelTemplateRegistration()
        {
            return _element.ReferencesFilePerModel();
        }

        public bool IsCustomTemplateRegistration()
        {
            return _element.ReferencesCustom();
        }

        protected bool Equals(TemplateRegistration other)
        {
            return Equals(_element, other._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TemplateRegistration)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }
}
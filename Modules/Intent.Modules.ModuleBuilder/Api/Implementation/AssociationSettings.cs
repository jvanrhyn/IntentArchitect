using System;
using System.Collections.Generic;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;
using System.Linq;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiModelImplementationTemplate", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class AssociationSettings : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Association Settings";
        private readonly IElement _element;

        public AssociationSettings(IElement element)
        {
            if (element.SpecializationType != SpecializationType)
            {
                throw new ArgumentException($"Invalid element type {element.SpecializationType}", nameof(element));
            }
            _element = element;
        }

        public string Id => _element.Id;
        public string Name => _element.Name;
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;
        [IntentManaged(Mode.Fully)]
        public AssociationEndSettings DestinationEnd => _element.ChildElements
            .Where(x => x.SpecializationType == Api.AssociationEndSettings.SpecializationType)
            .Select(x => new AssociationEndSettings(x))
            .SingleOrDefault();

        [IntentManaged(Mode.Fully)]
        public AssociationEndSettings SourceEnd => _element.ChildElements
            .Where(x => x.SpecializationType == Api.AssociationEndSettings.SpecializationType)
            .Select(x => new AssociationEndSettings(x))
            .SingleOrDefault();

        protected bool Equals(AssociationSettings other)
        {
            return Equals(_element, other._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssociationSettings)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }
}
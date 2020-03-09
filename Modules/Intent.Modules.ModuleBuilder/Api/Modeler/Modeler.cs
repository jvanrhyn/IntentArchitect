﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.IArchitect.Common.Types;
using Intent.Metadata.Models;
using Intent.Modules.Common;

namespace Intent.Modules.ModuleBuilder.Api.Modeler
{
    public class Modeler
    {
        public static string[] RequiredSpecializationTypes = new string[] { Constants.ElementSpecializationTypes.Modeler, Constants.ElementSpecializationTypes.ModelerExtension };

        public Modeler(IElement element)
        {
            if (!RequiredSpecializationTypes.Contains(element.SpecializationType))
            {
                throw new ArgumentException($"Invalid element [{element}]");
            }

            Name = element.Name;
            IsExtension = element.SpecializationType == Constants.ElementSpecializationTypes.ModelerExtension;
            PackageSettings = new PackageSettings(element.ChildElements.SingleOrDefault(x => x.SpecializationType == PackageSettings.SpecializationType));
            ElementSettings = element.ChildElements.Where(x => x.SpecializationType == ElementSetting.RequiredSpecializationType).Select(x => new ElementSetting(x)).OrderBy(x => x.SpecializationType).ToList();
            AssociationSettings = element.ChildElements.Where(x => x.SpecializationType == AssociationSetting.RequiredSpecializationType).Select(x => new AssociationSetting(x)).OrderBy(x => x.SpecializationType).ToList();
        }

        public string Name { get; }
        public bool IsExtension { get; }
        public PackageSettings PackageSettings { get; }
        public IList<ElementSetting> ElementSettings { get; }
        public IList<AssociationSetting> AssociationSettings { get; }
    }

    public class TypeOrder
    {
        public TypeOrder(IAttribute attribute)
        {
            Order = attribute.GetStereotypeProperty("Creation Options", "Type Order", attribute.Type.Element.GetStereotypeProperty<int?>("Default Creation Options", "Type Order", null));
            Type = attribute.Type.Element.Name;
        }
        public int? Order { get; set; }
        public string Type { get; set; }
    }

    public class IconModel
    {
        public static IconModel CreateIfSpecified(IStereotype stereotype)
        {
            if (stereotype == null)
            {
                return null;
            }
            if (!Enum.TryParse<IconType>(stereotype.GetProperty<string>("Type"), out var type))
            {
                type = IconType.UrlImagePath;
            }
            return new IconModel()
            {
                Type = type,
                Source = stereotype.GetProperty<string>("Source"),
            };
        }

        public IconType Type { get; set; }
        public string Source { get; set; }
    }

    public class AssociationSetting
    {
        public const string RequiredSpecializationType = "Association Setting";

        public AssociationSetting(IElement element)
        {
            if (element.SpecializationType != RequiredSpecializationType)
            {
                throw new ArgumentException($"Invalid element [{element}]");
            }

            SpecializationType = element.Name;
            Icon = IconModel.CreateIfSpecified(element.GetStereotype("Icon (Full)"));
            //SourceEnd =
            throw new NotImplementedException();
        }

        public string SpecializationType { get; set; }

        public IconModel Icon { get; set; }

        public AssociationEndSetting SourceEnd { get; set; }

        public AssociationEndSetting TargetEnd { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}'";
        }
    }

    public class AssociationEndSetting
    {
        public string[] TargetTypes { get; set; }

        public bool? IsNavigableEnabled { get; set; }

        public bool? IsNullableEnabled { get; set; }

        public bool? IsCollectionEnabled { get; set; }

        public bool? IsNavigableDefault { get; set; }

        public bool? IsNullableDefault { get; set; }

        public bool? IsCollectionDefault { get; set; }
    }
}
﻿using System;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.ModuleBuilder.Helpers;

namespace Intent.Modules.ModuleBuilder.Api
{
    public class ModelerModelType
    {
        public const string RequiredSpecializationType = "Element Settings";

        private readonly IElement _element;

        public ModelerModelType(IElement element)
        {
            if (element.SpecializationType != RequiredSpecializationType)
            {
                throw new InvalidOperationException($"Cannot load {nameof(ModelerModelType)} from element of type {element.SpecializationType}");
            }

            _element = element;
        }

        public string Id => _element.Id;
        public string ClassName => _element.Name.ToCSharpIdentifier();
        public string InterfaceName => $"{ClassName}";
        public string Namespace => _element.GetStereotypeProperty<string>("Model Type Settings", "Namespace");
        public string LoadMethod => _element.GetStereotypeProperty<string>("Model Type Settings", "Load Method");
        public string PerModelTemplate => _element.GetStereotypeProperty<string>("Model Type Settings", "Per Model Template");
        public string SingleListTemplate => _element.GetStereotypeProperty<string>("Model Type Settings", "Per List Template");
        public Modeler Modeler => new Modeler(this._element.ParentElement);
    }
}
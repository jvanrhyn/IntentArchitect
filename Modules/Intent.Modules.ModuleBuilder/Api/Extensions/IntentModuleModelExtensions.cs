using System;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    public static class IntentModuleModelExtensions
    {
        public static PackageSettings GetPackageSettings(this IntentModuleModel model)
        {
            var stereotype = model.GetStereotype("Package Settings");
            return stereotype != null ? new PackageSettings(stereotype) : null;
        }

        public static bool HasPackageSettings(this IntentModuleModel model)
        {
            return model.HasStereotype("Package Settings");
        }


        public class PackageSettings
        {
            private IStereotype _stereotype;

            public PackageSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public bool IncludeInModule()
            {
                return _stereotype.GetProperty<bool>("Include in Module");
            }

            public IElement[] ReferenceInDesigner()
            {
                return _stereotype.GetProperty<IElement[]>("Reference in Designer");
            }

        }

    }
}
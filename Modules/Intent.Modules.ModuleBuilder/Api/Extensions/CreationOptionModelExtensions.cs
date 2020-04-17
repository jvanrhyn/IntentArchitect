using System;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiModelExtensions", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    public static class CreationOptionModelExtensions
    {
        public static OptionSettings GetOptionSettings(this CreationOptionModel model)
        {
            var stereotype = model.GetStereotype("Option Settings");
            return stereotype != null ? new OptionSettings(stereotype) : null;
        }


        public class OptionSettings
        {
            private IStereotype _stereotype;

            public OptionSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Shortcut()
            {
                return _stereotype.GetProperty<string>("Shortcut");
            }

            public string DefaultName()
            {
                return _stereotype.GetProperty<string>("Default Name");
            }

            public int? TypeOrder()
            {
                return _stereotype.GetProperty<int?>("Type Order");
            }

            public bool AllowMultiple()
            {
                return _stereotype.GetProperty<bool>("Allow Multiple");
            }

        }

    }
}
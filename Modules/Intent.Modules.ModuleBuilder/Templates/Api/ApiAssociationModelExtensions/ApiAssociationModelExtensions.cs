// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ModuleBuilder.Templates.Api.ApiAssociationModelExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.ModuleBuilder.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ApiAssociationModelExtensions : IntentRoslynProjectItemTemplateBase<AssociationSettingsModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Collections.Generic;\r\nusing System.Linq;\r\n\r\n[assembly: DefaultIntent" +
                    "Managed(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
  foreach(var targetType in Model.SourceEnd.TargetTypes()) {  
            
            #line default
            #line hidden
            this.Write("        [IntentManaged(Mode.Fully)]\r\n        public static IList<");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.TargetEnd.ApiModelName));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.TargetEnd.ApiPropertyName));
            
            #line default
            #line hidden
            this.Write("(this ");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(targetType.ApiModelName));
            
            #line default
            #line hidden
            this.Write(" model)\r\n        {\r\n            return model.InternalElement.AssociatedElements\r\n" +
                    "                .Where(x => x.Association.SpecializationType == ");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ApiModelName));
            
            #line default
            #line hidden
            this.Write(".SpecializationType && x.IsTargetEnd())\r\n                .Select(x => ");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ApiModelName));
            
            #line default
            #line hidden
            this.Write(".CreateFromEnd(x).TargetEnd)\r\n                .ToList();\r\n        }\r\n\r\n");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
  }  
            
            #line default
            #line hidden
            
            #line 30 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
  foreach(var targetType in Model.TargetEnd.TargetTypes()) {  
            
            #line default
            #line hidden
            this.Write("        [IntentManaged(Mode.Fully)]\r\n        public static IList<");
            
            #line 32 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.SourceEnd.ApiModelName));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 32 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.SourceEnd.ApiPropertyName));
            
            #line default
            #line hidden
            this.Write("(this ");
            
            #line 32 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(targetType.ApiModelName));
            
            #line default
            #line hidden
            this.Write(" model)\r\n        {\r\n            return model.InternalElement.AssociatedElements\r\n" +
                    "                .Where(x => x.Association.SpecializationType == ");
            
            #line 35 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ApiModelName));
            
            #line default
            #line hidden
            this.Write(".SpecializationType && x.IsSourceEnd())\r\n                .Select(x => ");
            
            #line 36 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ApiModelName));
            
            #line default
            #line hidden
            this.Write(".CreateFromEnd(x).SourceEnd)\r\n                .ToList();\r\n        }\r\n\r\n");
            
            #line 40 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiAssociationModelExtensions\ApiAssociationModelExtensions.tt"
  }  
            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

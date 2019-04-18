// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Angular.Templates.Model.AngularModelTemplate
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AngularModelTemplate : IntentProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nexport class ");
            
            #line 9 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" \r\n{\r\n    public static ");
            
            #line 11 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" Create(");
            
            #line 11 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ConstructorParameters()));
            
            #line default
            #line hidden
            this.Write(") \r\n    {\r\n        return new ");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n        {\r\n");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
 foreach (var field in Model.Fields) {
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 16 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 16 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToCamelCase().PrefixIdentifierIfKeyword()));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("        };\r\n    }\r\n");
            
            #line 20 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"

foreach (var field in Model.Fields)
{

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"

    foreach (var line in field.GetXmlDocLines())
    {

            
            #line default
            #line hidden
            this.Write("    /// ");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(line));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 30 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 33 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertyAttributes(field)));
            
            #line default
            #line hidden
            this.Write("\r\n    public ");
            
            #line 34 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeInfo(field.TypeReference)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" {get; set;}\r\n");
            
            #line 35 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Model\AngularModelTemplate\AngularModelTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

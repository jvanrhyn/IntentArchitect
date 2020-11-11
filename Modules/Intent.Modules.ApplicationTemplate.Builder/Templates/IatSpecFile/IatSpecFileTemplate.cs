// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ApplicationTemplate.Builder.Templates.IatSpecFile
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.ApplicationTemplate.Builder.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class IatSpecFileTemplate : IntentTemplateBase<ApplicationTemplateModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<applicationTemplate>\r\n  <id>");
            
            #line 11 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("</id>\r\n  <version>");
            
            #line 12 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Version));
            
            #line default
            #line hidden
            this.Write("</version>\r\n  <supportedClientVersions>");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.SupportedClientVersions ?? ""));
            
            #line default
            #line hidden
            this.Write("</supportedClientVersions>\r\n  <displayName>");
            
            #line 14 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.DisplayName));
            
            #line default
            #line hidden
            this.Write("</displayName>\r\n  <shortDescription>");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Description ?? ""));
            
            #line default
            #line hidden
            this.Write("</shortDescription>\r\n  <authors>");
            
            #line 16 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Authors ?? ""));
            
            #line default
            #line hidden
            this.Write("</authors>\r\n  <priority>");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Priority ?? "0"));
            
            #line default
            #line hidden
            this.Write("</priority>\r\n  <icon type=\"");
            
            #line 18 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Icon.Type));
            
            #line default
            #line hidden
            this.Write("\" source=\"");
            
            #line 18 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Icon.Source));
            
            #line default
            #line hidden
            this.Write("\" />\r\n  <componentGroups>\r\n");
            
            #line 20 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
  foreach(var @group in Model.Groups) { 
            
            #line default
            #line hidden
            this.Write("    <group name=\"");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(@group.Name));
            
            #line default
            #line hidden
            this.Write("\">\r\n      <components>\r\n");
            
            #line 23 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
      foreach(var component in @group.Components) { 
            
            #line default
            #line hidden
            this.Write("        <component name=\"");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(component.Name));
            
            #line default
            #line hidden
            this.Write("\" included=\"");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(component.IncludeByDefault.ToString().ToLower()));
            
            #line default
            #line hidden
            this.Write("\">\r\n          <description>");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(component.Description ?? ""));
            
            #line default
            #line hidden
            this.Write("</description>\r\n          <icon type=\"");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(component.Icon.Type));
            
            #line default
            #line hidden
            this.Write("\" source=\"");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(component.Icon.Source));
            
            #line default
            #line hidden
            this.Write("\"/>\r\n          <modules>\r\n");
            
            #line 28 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
          foreach(var module in component.Modules) { 
            
            #line default
            #line hidden
            this.Write("            <module id=\"");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module.Name));
            
            #line default
            #line hidden
            this.Write("\" version=\"");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module.Version));
            
            #line default
            #line hidden
            this.Write("\" />\r\n");
            
            #line 30 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
          } 
            
            #line default
            #line hidden
            this.Write("          </modules>\r\n        </component>\r\n");
            
            #line 33 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
      } 
            
            #line default
            #line hidden
            this.Write("      </components>\r\n    </group>\r\n");
            
            #line 36 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ApplicationTemplate.Builder\Templates\IatSpecFile\IatSpecFileTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write("  </componentGroups>\r\n</applicationTemplate>\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

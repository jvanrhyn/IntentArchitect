﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.VisualStudio.Projects.Templates.CoreWeb.CsProject
{
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.VisualStudio;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.VisualStudio.Projects\Templates\CoreWeb\CsProject\CoreWebCSProjectTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class CoreWebCSProjectTemplate : IntentProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            this.Write(" \r\n");
            this.Write(@"<Project Sdk=""Microsoft.NET.Sdk.Web"">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.AspNetCore.All"" Version=""2.1.1"" />
    <PackageReference Include=""Microsoft.VisualStudio.Web.CodeGeneration.Design"" Version=""2.1.1"" />
  </ItemGroup>

  <ItemGroup>
    <DotNetCliToolReference Include=""Microsoft.VisualStudio.Web.CodeGeneration.Tools"" Version=""2.0.4"" />
  </ItemGroup>

</Project>
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.VisualStudio.Projects.Templates.AssemblyInfo
{
    using Intent.Modules.Common.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.VisualStudio.Projects\Templates\AssemblyInfo\AssemblyInfoTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class AssemblyInfoTemplate : IntentProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            this.Write(" \r\n");
            this.Write(@"   
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(""");
            
            #line 20 "C:\Dev\Intent.Modules\Modules\Intent.Modules.VisualStudio.Projects\Templates\AssemblyInfo\AssemblyInfoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Project.Name));
            
            #line default
            #line hidden
            this.Write("\")]\r\n[assembly: AssemblyDescription(\"\")]\r\n[assembly: AssemblyConfiguration(\"\")]\r\n" +
                    "[assembly: AssemblyCompany(\"\")]\r\n[assembly: AssemblyProduct(\"");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.VisualStudio.Projects\Templates\AssemblyInfo\AssemblyInfoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Project.Name));
            
            #line default
            #line hidden
            this.Write(@""")]
[assembly: AssemblyCopyright(""Copyright ©  2016"")]
[assembly: AssemblyTrademark("""")]
[assembly: AssemblyCulture("""")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid(""");
            
            #line 35 "C:\Dev\Intent.Modules\Modules\Intent.Modules.VisualStudio.Projects\Templates\AssemblyInfo\AssemblyInfoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Guid.NewGuid()));
            
            #line default
            #line hidden
            this.Write(@""")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion(""1.0.*"")]
[assembly: AssemblyVersion(""1.0.0.0"")]
[assembly: AssemblyFileVersion(""1.0.0.0"")]
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

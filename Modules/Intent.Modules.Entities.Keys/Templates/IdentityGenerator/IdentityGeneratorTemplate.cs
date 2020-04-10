﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.Keys.Templates.IdentityGenerator
{
    using Intent.Modelers.Domain.Api;
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Keys\Templates\IdentityGenerator\IdentityGeneratorTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class IdentityGeneratorTemplate : IntentRoslynProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Keys\Templates\IdentityGenerator\IdentityGeneratorTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Runtime.InteropServices;\r\n");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Keys\Templates\IdentityGenerator\IdentityGeneratorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)] \r\n\r\nnamespace ");
            
            #line 23 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Keys\Templates\IdentityGenerator\IdentityGeneratorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities.Keys\Templates\IdentityGenerator\IdentityGeneratorTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"
    {
        /// <summary>
        /// Generates sequential GUIDs for SQL Server.
        /// https://github.com/richardtallent/RT.Comb
        /// </summary>
        /// <returns></returns>
        public static Guid NewSequentialId()
        {
            return RT.Comb.Provider.Sql.Create();
        }
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

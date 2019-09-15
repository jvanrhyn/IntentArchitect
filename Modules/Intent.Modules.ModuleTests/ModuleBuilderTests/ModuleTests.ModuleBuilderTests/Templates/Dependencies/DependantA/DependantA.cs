// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ModuleTests.ModuleBuilderTests.Templates.Dependencies.DependantA
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modelers.Domain.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class DependantA : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nusing System;\r\n");
            
            #line 10 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write(@"
// Mode.Fully will overwrite file on each run. 
// Add in explicit [IntentManaged.Ignore] attributes to class or methods. Alternatively change to Mode.Merge (additive) or Mode.Ignore (once-off)
[assembly: DefaultIntentManaged(Mode.Fully)]

namespace ");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
  // The following is an example template implementation
    foreach(var attribute in Model.Attributes) { 
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Types.Get(attribute.Type)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\r\n");
            
            #line 23 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
  } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
  foreach(var operation in Model.Operations) { 
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.ReturnType != null ? Types.Get(operation.ReturnType.Type) : "void"));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(", ", operation.Parameters.Select(x => string.Format("{0} {1}", Types.Get(x.Type), x.Name)))));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            throw new NotImplementedException();\r\n        }\r\n\r\n");
            
            #line 31 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleTests\ModuleBuilderTests\ModuleTests.ModuleBuilderTests\Templates\Dependencies\DependantA\DependantA.tt"
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

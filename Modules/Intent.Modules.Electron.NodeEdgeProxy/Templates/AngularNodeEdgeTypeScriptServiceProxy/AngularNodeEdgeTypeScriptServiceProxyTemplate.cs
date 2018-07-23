﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Electron.NodeEdgeProxy.Templates.AngularNodeEdgeTypeScriptServiceProxy
{
    using Intent.MetaModel.Service;
    using Intent.SoftwareFactory.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AngularNodeEdgeTypeScriptServiceProxyTemplate : IntentProjectItemTemplateBase<ServiceModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("namespace ");
            
            #line 7 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n    export class ");
            
            #line 8 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Proxy {\r\n        static $inject = [\"EdgeService\"];\r\n        constructor(\r\n       " +
                    "     private readonly edgeService: IEdgeService\r\n        ) { }\r\n");
            
            #line 13 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
      foreach (var o in Model.Operations)
        {


            
            #line default
            #line hidden
            this.Write("\r\n        ");
            
            #line 18 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(o.Name.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 18 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMethodDefinitionParameters(o)));
            
            #line default
            #line hidden
            this.Write("): ng.IPromise<");
            
            #line 18 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetReturnType(o)));
            
            #line default
            #line hidden
            this.Write("> {\r\n            return this.edgeService.callMethod<");
            
            #line 19 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetReturnType(o)));
            
            #line default
            #line hidden
            this.Write(">(\"");
            
            #line 19 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TypeName));
            
            #line default
            #line hidden
            this.Write("\", \"");
            
            #line 19 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(o.Name));
            
            #line default
            #line hidden
            this.Write("\"");
            
            #line 19 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMethodCallParameters(o)));
            
            #line default
            #line hidden
            this.Write(");\r\n        }\r\n");
            
            #line 21 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("    }\r\n\r\n    angular.module(\"App\").service(\"");
            
            #line 26 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Proxy\", ");
            
            #line 26 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularNodeEdgeTypeScriptServiceProxy\AngularNodeEdgeTypeScriptServiceProxyTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Proxy);\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

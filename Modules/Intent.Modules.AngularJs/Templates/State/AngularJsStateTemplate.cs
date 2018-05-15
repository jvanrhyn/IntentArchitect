﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AngularJs.Templates.State
{
    using Intent.SoftwareFactory.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class AngularJsStateTemplate : IntentTypescriptProjectItemTemplateBase<ViewStateModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"




            
            #line default
            #line hidden
            this.Write("// NOTE: NB! This is an R&D Module.\r\n\'use strict\';\r\nnamespace ");
            
            #line 19 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n    export class ");
            
            #line 20 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" implements ng.ui.IState {\r\n//IntentManaged[state]\r\n        static state = () => " +
                    "<ng.ui.IState>{\r\n            url: \"");
            
            #line 23 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Url));
            
            #line default
            #line hidden
            this.Write("\",\r\n            templateUrl: \"App/States/");
            
            #line 24 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 24 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("View.html\",\r\n            resolve: {\r\n                viewModel: [\"");
            
            #line 26 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\",\r\n                    (manager: ");
            
            #line 27 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(") => {\r\n                        return new ");
            
            #line 28 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ViewModelName));
            
            #line default
            #line hidden
            this.Write("({\r\n");
            
            #line 29 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
	foreach(var command in Model.Commands) {
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t");
            
            #line 30 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            
            #line default
            #line hidden
            this.Write("Command: new Command(() => manager.");
            
            #line 30 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            
            #line default
            #line hidden
            this.Write("()),\r\n");
            
            #line 31 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t});\r\n                    }\r\n                ]\r\n            },\r\n            " +
                    "controller: [\r\n                \"$scope\", \"viewModel\", ($scope: ng.IScope, viewMo" +
                    "del: ");
            
            #line 37 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ViewModelName));
            
            #line default
            #line hidden
            this.Write(@") => {
                    (<any>$scope).vm = viewModel;
                    $scope.$on(""$destroy"", () => viewModel.dispose());
                }
            ]
        };
//IntentManaged[state]

        static $inject = [];
        constructor() { 
        }

");
            
            #line 49 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
	foreach(var command in Model.Commands) {
            
            #line default
            #line hidden
            this.Write("\tpublic ");
            
            #line 50 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            
            #line default
            #line hidden
            this.Write("() {\r\n\t\t// your implementation here...\r\n\t}\r\n");
            
            #line 53 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n    angular.module(\"App\").service(\"");
            
            #line 56 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\", ");
            
            #line 56 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.AngularJs\Templates\State\AngularJsStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(");\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

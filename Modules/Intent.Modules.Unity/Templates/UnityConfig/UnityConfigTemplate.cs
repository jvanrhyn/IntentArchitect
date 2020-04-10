﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Unity.Templates.UnityConfig
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class UnityConfigTemplate : IntentRoslynProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\nusing System;\r\nusing System.Linq;\r\nusing System.Collections.Generic;\r\nusing Un" +
                    "ity;\r\nusing Unity.RegistrationByConvention;\r\n");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge)]\r\n    public class ");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        private static void RegisterTypes(IUnityContainer container)
        {
            LoadConventions(container);
            LoadGeneratedRegistrations(container);
            LoadCustom(container);
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name=""container"">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types (unless you want to change the defaults), 
        /// as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        [IntentManaged(Mode.Ignore)]
        private static void LoadCustom(IUnityContainer container)
        {
            //Add Custom Unity Registrations
        }

        private static void LoadConventions(IUnityContainer container)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => 
");
            
            #line 64 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
  foreach(var project in ApplicationProjects) { 
            
            #line default
            #line hidden
            this.Write("                            ");
            
            #line 65 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(project == ApplicationProjects.First() ? "" : "|| "));
            
            #line default
            #line hidden
            this.Write("x.GetName().Name.Equals(\"");
            
            #line 65 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(project.Name));
            
            #line default
            #line hidden
            this.Write("\") \r\n");
            
            #line 66 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
  } 
            
            #line default
            #line hidden
            this.Write(@"                      ).ToArray();
            container.RegisterTypes(
               AllClasses.FromAssemblies(assemblies),
               WithMappings.FromMatchingInterface,
               WithName.Default,
               WithLifetime.PerResolve);
        }

        private static void LoadGeneratedRegistrations(IUnityContainer container)
        {
            ");
            
            #line 77 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Unity\Templates\UnityConfig\UnityConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Registrations()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.IdentityServer.Templates.Scopes
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.IdentityServer\Templates\Scopes\IdentityServerScopesTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class IdentityServerScopesTemplate : IntentRoslynProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.IdentityServer\Templates\Scopes\IdentityServerScopesTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Web;\r\nusing IdentityServer3.Core;\r\nusing IdentityServer3.Core.Models;\r\n\r\n[asse" +
                    "mbly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.IdentityServer\Templates\Scopes\IdentityServerScopesTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(@"
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
        {
            StandardScopes.OpenId,
            StandardScopes.Profile,
            StandardScopes.Email,
            StandardScopes.Roles,

            new Scope
            {
                Name = ""api"",
                DisplayName = ""Api"",
                Type = ScopeType.Resource,
                Emphasize = true,

                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim(Constants.ClaimTypes.Email, true),
                    new ScopeClaim(Constants.ClaimTypes.Name, true),
                    new ScopeClaim(Constants.ClaimTypes.GivenName, true),
                    new ScopeClaim(Constants.ClaimTypes.FamilyName, true),
                    new ScopeClaim(Constants.ClaimTypes.Role, true),
                    new ScopeClaim(Constants.ClaimTypes.IssuedAt, true),
                }
            }
        };
        }
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

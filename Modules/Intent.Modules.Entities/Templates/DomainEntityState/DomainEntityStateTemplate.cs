﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.Templates.DomainEntityState
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DomainEntityStateTemplate : Intent.Modules.Common.Templates.IntentRoslynProjectItemTemplateBase<ClassModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\n");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassAnnotations(Model)));
            
            #line default
            #line hidden
            this.Write("\r\n    public ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.IsAbstract ? "abstract " : ""));
            
            #line default
            #line hidden
            this.Write("partial class ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetBaseClass(Model)));
            
            #line default
            #line hidden
            this.Write(", I");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetInterfaces(Model)));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Constructors(Model)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BeforeProperties(Model)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
  foreach (var attribute in Model.Attributes)
    {
		string attributeType = Types.Get(attribute.Type);

            
            #line default
            #line hidden
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertyBefore(attribute)));
            
            #line default
            #line hidden
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
      
        if (!CanWriteDefaultAttribute(attribute)) {
            continue;
        }
            
            #line default
            #line hidden
            
            #line 33 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertyFieldAnnotations(attribute)));
            
            #line default
            #line hidden
            this.Write("\r\n        private ");
            
            #line 34 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attributeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 34 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 35 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertyAnnotations(attribute)));
            
            #line default
            #line hidden
            this.Write("\r\n        public ");
            
            #line 36 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attributeType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 36 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" \r\n        {\r\n            get { return ");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write("; }\r\n            set\r\n            {\r\n");
            
            #line 41 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertySetterBefore(attribute)));
            
            #line default
            #line hidden
            
            #line 41 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
		
		if (attributeType == "date")
		{
			if (!attribute.Type.IsNullable)
			{
            
            #line default
            #line hidden
            this.Write("                ");
            
            #line 46 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write(" = value.Date;\r\n");
            
            #line 47 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
			}
			else
			{
            
            #line default
            #line hidden
            this.Write("                ");
            
            #line 50 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write(" = (value == null) ? value : value.Value.Date;\r\n");
            
            #line 51 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
			}
		}
		else
		{
            
            #line default
            #line hidden
            this.Write("                ");
            
            #line 55 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write(" = value;\r\n");
            
            #line 56 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
		}

            
            #line default
            #line hidden
            
            #line 57 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertySetterAfter(attribute)));
            
            #line default
            #line hidden
            this.Write("            }\r\n        }\r\n");
            
            #line 59 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
  }
	if (Model.AssociatedClasses.Any()) {
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 62 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
 	}
	foreach (var associatedClass in Model.AssociatedClasses)
    {

            
            #line default
            #line hidden
            
            #line 65 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationBefore(associatedClass)));
            
            #line default
            #line hidden
            
            #line 65 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
 	
		if (!CanWriteDefaultAssociation(associatedClass) || !associatedClass.IsNavigable) 
		{
			continue;
        }

            
            #line default
            #line hidden
            this.Write("\t\tprivate ");
            
            #line 70 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(Types.Get(associatedClass))));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 70 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associatedClass.Name().ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 71 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PropertyAnnotations(associatedClass)));
            
            #line default
            #line hidden
            this.Write("\r\n        public virtual ");
            
            #line 72 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(Types.Get(associatedClass))));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 72 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associatedClass.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("\r\n        {\r\n            get\r\n            {\r\n");
            
            #line 76 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
		string associatedClassReturn;
		if (associatedClass.Multiplicity == Multiplicity.Many)
		{
			associatedClassReturn = String.Format("{0} ?? ({0} = new List<{1}>())", associatedClass.Name().ToPrivateMember(), associatedClass.Class.Name + "");
		}
		else
		{
			associatedClassReturn = associatedClass.Name().ToPrivateMember();
		}

            
            #line default
            #line hidden
            this.Write("                return ");
            
            #line 86 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associatedClassReturn));
            
            #line default
            #line hidden
            this.Write(";\r\n            }\r\n            set\r\n            {    \r\n                ");
            
            #line 90 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associatedClass.Name().ToPrivateMember()));
            
            #line default
            #line hidden
            this.Write(" = value;\r\n            }\r\n        }\r\n");
            
            #line 93 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AssociationAfter(associatedClass)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 94 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Entities\Templates\DomainEntityState\DomainEntityStateTemplate.tt"
  }
            
            #line default
            #line hidden
            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}

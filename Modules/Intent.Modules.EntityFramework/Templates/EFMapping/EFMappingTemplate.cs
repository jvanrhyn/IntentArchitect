﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.EntityFramework.Templates.EFMapping
{
    using Intent.MetaModel.Domain;
    using Intent.SoftwareFactory.Templates;
    using Intent.SoftwareFactory.MetaData;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class EFMappingTemplate : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n\r\n");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
//Some initial validation
    foreach (var associationEnd in Model.AssociatedClasses)
    {
        var association = associationEnd.Association;
 
        //if there is more than 1 parent association && there are any which are not 0..1->1 (this is a manual inheritance mapping)
        var multipleCompositions = Model.AssociatedClasses.Where(ae => ae.Association.AssociationType == AssociationType.Composition && ae.Association.TargetEnd.Class == Model);
        if (multipleCompositions.Count() > 1)
        {
            throw new Exception(string.Format("Unsupported Mapping - {0} each have a Compositional relationship with {1}.", multipleCompositions.Select(x => x.Class.Name).Aggregate((x, y) => x + ", " + y), Model.Name));
        }

        if (!association.TargetEnd.IsNavigable)
        {
            throw new Exception(string.Format("Unsupported Source Needs to be Navigable to Target relationship  {0} on {1} ", association.ToString(), association.TargetEnd.Class.Name));
        }

        //Unsupported Associations
        if ((association.AssociationType == AssociationType.Aggregation ) && ( association.RelationshipString() == "1->0..1"))
        {
            throw new Exception(string.Format("Unsupported Aggregation relationship  {0} - this relationship implies composition", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Aggregation ) && ( association.RelationshipString() == "1->1"))
        {
            throw new Exception(string.Format("Unsupported Aggregation relationship  {0} - this relationship implies composition", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Aggregation ) && ( association.RelationshipString() == "1->*"))
        {
            throw new Exception(string.Format("Unsupported Aggregation relationship {0}, this relationship implies Composition", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString() == "0..1->0..1"))
        {
            throw new Exception(string.Format("Unsupported Composition relationship {0}", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString() == "0..1->*"))
        {
            throw new Exception(string.Format("Unsupported Composition relationship {0}, this relationship implies aggregation", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString().StartsWith("*->")))
        {
            throw new Exception(string.Format("Unsupported Composition relationship {0}, this relationship implies aggregation", association.ToString()));
        }
        //Naviagability Requirement
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString() == "0..1->1") && (!association.SourceEnd.IsNavigable))
        {
            throw new Exception(string.Format("Unsupported. IsNavigable from Composition Required for Composition relationship {0}", association.ToString()));
        }
    }


            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Data.Entity.ModelConfiguration;\r\nusing System.Data.En" +
                    "tity.Infrastructure.Annotations;\r\nusing System.ComponentModel.DataAnnotations.Sc" +
                    "hema;\r\n");
            
            #line 69 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 73 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public partial class ");
            
            #line 75 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Mapping : EntityTypeConfiguration<");
            
            #line 75 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n    \r\n        public ");
            
            #line 78 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Mapping()\r\n        {\r\n");
            
            #line 80 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
    if (Model.ParentClass == null || Model.ParentClass.GetStereotypeProperty<string>("InheritanceMapping", "Type") != "TPH")
    {
            
            #line default
            #line hidden
            this.Write("            this.ToTable(\"");
            
            #line 82 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("\");\r\n");
            
            #line 83 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
    }
    if (Model.GetStereotypeProperty<string>("InheritanceMapping", "Type") == "TPH")
    {
        foreach (var subClass in Model.ChildClasses)
        {

            
            #line default
            #line hidden
            this.Write("            this.Map<");
            
            #line 89 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(subClass.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(">(m => m.Requires(\"DbSpecialization\").HasValue((int)");
            
            #line 89 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Specialization.");
            
            #line 89 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(subClass.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("));\r\n");
            
            #line 90 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
      }
    }
	bool mapPk = true;
    //Key Mapping
    if (Model.ParentClass != null && Model.ParentClass.GetStereotypeProperty<string>("InheritanceMapping", "Type") == "TPH")    
    {
		mapPk = false;
        //No Key mapping required
    } 

	if (ImplicitSurrogateKey) {
            
            #line default
            #line hidden
            this.Write("            this.HasKey(x => x.Id);\r\n            this.Property(x => x.Id).HasColu" +
                    "mnName(\"Id\");\r\n");
            
            #line 103 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
  }  
    foreach (var attribute in Model.Attributes)
    {
		if (mapPk && attribute.Name.ToLower() == "id")
        {
			if (ImplicitSurrogateKey) {
				throw new Exception(string.Format("Surrogate Key is implicit for class {0}. Either remove the 'id' attribute, or disable the 'Implicit Surrogate Key' option for this template", Model.Name));
            }

            
            #line default
            #line hidden
            this.Write("            this.HasKey(x => x.Id);\r\n            this.Property(x => x.Id).HasColu" +
                    "mnName(\"Id\");\r\n");
            
            #line 114 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
			continue;
        }
            
            #line default
            #line hidden
            this.Write("            this.Property(x => x.");
            
            #line 116 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 116 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

		if (!string.IsNullOrEmpty(attribute.GetStereotypeProperty<string>("Index", "UniqueKey")))
		{
            
            #line default
            #line hidden
            this.Write("                .HasColumnAnnotation(\"Index\", new IndexAnnotation(new []\r\n       " +
                    "             {\r\n");
            
            #line 121 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
			foreach(var index in attribute.Stereotypes.Where(x => x.Name == "Index")) { 
            
            #line default
            #line hidden
            this.Write("                        new IndexAttribute(\"");
            
            #line 122 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("_");
            
            #line 122 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(index.GetProperty("UniqueKey", "Unique1")));
            
            #line default
            #line hidden
            this.Write("\", ");
            
            #line 122 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(index.GetProperty("Order", "1")));
            
            #line default
            #line hidden
            this.Write(") { IsUnique = ");
            
            #line 122 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(index.GetProperty("IsUnique", "false")));
            
            #line default
            #line hidden
            this.Write(" },\r\n");
            
            #line 123 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

			}
            
            #line default
            #line hidden
            this.Write("                    }))");
            
            #line 125 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

        }
        if (!attribute.IsNullable){
            
            #line default
            #line hidden
            this.Write("\r\n                .IsRequired()");
            
            #line 129 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

        }

        if (attribute.Type.Name == "string" )
        {
            var maxLength = attribute.GetStereotypeProperty<int?>("Text", "MaxLength");    
            if (maxLength.HasValue){
        
            
            #line default
            #line hidden
            this.Write("\r\n                .HasMaxLength(");
            
            #line 138 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(maxLength.Value));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 138 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

            }
        }

        var decimalPrecision = attribute.GetStereotypeProperty<int?>("Numeric", "Precision");
        var decimalScale = attribute.GetStereotypeProperty<int?>("Numeric", "Scale");
        if (decimalPrecision.HasValue && decimalScale.HasValue){
            
            #line default
            #line hidden
            this.Write("\r\n                .HasPrecision(");
            
            #line 146 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(decimalPrecision));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 146 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(decimalScale));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 146 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

        }
        switch (attribute.Type.Name)
        {
            case "date" :
            
            #line default
            #line hidden
            this.Write("\r\n                .HasColumnType(\"date\")");
            
            #line 152 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

                break;
            case "datetime" :
            
            #line default
            #line hidden
            this.Write("\r\n                .HasColumnType(\"datetime2\")");
            
            #line 156 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

                break;
        }    

            
            #line default
            #line hidden
            this.Write(";\r\n\r\n");
            
            #line 161 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
  }
            
            #line default
            #line hidden
            
            #line 162 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
    foreach (var associationEnd in Model.AssociatedClasses)
    {

		if (associationEnd != associationEnd.Association.TargetEnd)
        {
			continue;
        }

        switch (associationEnd.Relationship())
        {
            case RelationshipType.OneToOne :
                MapOneToOne(associationEnd);
                break;
            case RelationshipType.OneToMany :
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 176 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("this.{0}(x => x.{1})", associationEnd.MinMultiplicity != "0" ? "HasRequired" : "HasOptional", associationEnd.Name().ToPascalCase())));
            
            #line default
            #line hidden
            this.Write("\r\n                .WithMany(");
            
            #line 177 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().IsNavigable ? "x => x." + associationEnd.OtherEnd().Name().ToPascalCase() : ""));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 178 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
				if (UseForeignKeys) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t.HasForeignKey(x => x.");
            
            #line 179 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id)\r\n");
            
            #line 180 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
				} else { 
            
            #line default
            #line hidden
            this.Write("                .Map(m => m.MapKey(\"");
            
            #line 181 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id\"))\r\n");
            
            #line 182 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
				} 
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 185 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
                  break;
            case RelationshipType.ManyToOne :
            
            #line default
            #line hidden
            this.Write("            this.HasMany(x => x.");
            
            #line 187 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                .");
            
            #line 188 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0}({1})", associationEnd.OtherEnd().MinMultiplicity != "0" ? "WithRequired" : "WithOptional", "x => x." + associationEnd.OtherEnd().Name().ToPascalCase())));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 189 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
				if (UseForeignKeys) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t.HasForeignKey(x => x.");
            
            #line 190 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id)\r\n");
            
            #line 191 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
				} else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t.Map(m => m.MapKey(\"");
            
            #line 192 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id\"))\r\n");
            
            #line 193 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
				} 
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 196 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
                  break;
            case RelationshipType.ManyToMany :
            
            #line default
            #line hidden
            this.Write("            this.HasMany(x => x.");
            
            #line 198 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                .WithMany(");
            
            #line 199 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().IsNavigable ? "x => x." + associationEnd.OtherEnd().Name().ToPascalCase() : ""));
            
            #line default
            #line hidden
            this.Write(")\r\n                .Map(m => \r\n                    {\r\n                        m.T" +
                    "oTable(\"");
            
            #line 202 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Class.Name.ToPascalCase() + associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("\");\r\n                        m.MapLeftKey(\"");
            
            #line 203 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Class.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id\");\r\n                        m.MapRightKey(\"");
            
            #line 204 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Class.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id\");\r\n                    });\r\n\r\n");
            
            #line 207 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
                  break;
        }       
    }

            
            #line default
            #line hidden
            this.Write("        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 214 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"

public void MapOneToOne(IAssociationEnd associationEnd)
{
    var parent = associationEnd.Association.SourceEnd;
    var child = associationEnd.Association.TargetEnd;

    string hasClause = associationEnd.MinMultiplicity != "0" ? "HasRequired" : "HasOptional";
    string withClause = "With" + (associationEnd.OtherEnd().MinMultiplicity != "0" ? "Required" : "Optional") + ((associationEnd.MinMultiplicity != "0") == (associationEnd.OtherEnd().MinMultiplicity != "0") ?  DeterminePrinciple(associationEnd)  : "");    

        
        #line default
        #line hidden
        
        #line 222 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write("            ");

        
        #line default
        #line hidden
        
        #line 223 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("this.{0}(x => x.{1})", hasClause, associationEnd.Name().ToPascalCase())));

        
        #line default
        #line hidden
        
        #line 223 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write("\r\n            ");

        
        #line default
        #line hidden
        
        #line 224 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(string.Format(".{0}({1})", withClause, associationEnd.OtherEnd().IsNavigable ? "x => x." + associationEnd.OtherEnd().Name().ToPascalCase(): "" )));

        
        #line default
        #line hidden
        
        #line 224 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write("\r\n");

        
        #line default
        #line hidden
        
        #line 225 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
  if ((associationEnd.Association.AssociationType == AssociationType.Composition && associationEnd.Association.RelationshipString() == "0..1->1")
            || (associationEnd.Association.AssociationType == AssociationType.Aggregation && associationEnd.Association.RelationshipString() == "0..1->1")
        )
    {
        
        #line default
        #line hidden
        
        #line 228 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write("            .Map(m => m.MapKey(\"");

        
        #line default
        #line hidden
        
        #line 229 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase() + "Id"));

        
        #line default
        #line hidden
        
        #line 229 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write("\"))\r\n");

        
        #line default
        #line hidden
        
        #line 230 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
    }
        
        #line default
        #line hidden
        
        #line 230 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
this.Write("            ;\r\n");

        
        #line default
        #line hidden
        
        #line 232 "C:\Dev\Intent.Modules\Modules\Intent.Modules.EntityFramework\Templates\EFMapping\EFMappingTemplate.tt"
    
}

public string DeterminePrinciple(IAssociationEnd associationEnd)
{
    if (associationEnd.Association.AssociationType == AssociationType.Composition )
    {
        return "Principal";
    }
    if (associationEnd.Association.AssociationType == AssociationType.Aggregation )
    {
        return "Dependent";
    }
    return "";
}



        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}

﻿using Intent.MetaModel.Domain;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;

namespace Intent.Modules.Entities.DDD.Templates.DomainEntityBehaviour
{
    partial class DomainEntityBehavioursTemplate : IntentRoslynProjectItemTemplateBase<IClass>, ITemplate//, IHasDecorators<AbstractDomainEntityDecorator>
    {
        public const string Identifier = "Intent.Entities.DDD.Behaviours";

        public DomainEntityBehavioursTemplate(IClass model, IProject project)
            : base(Identifier, project, model)
        {
        }

        public string ClassStateName => Model.Name;

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Id, new TemplateVersion(1, 0)));
        }

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: "I${Model.Name}Behaviours",
                fileExtension: "cs",
                defaultLocationInProject: "Domain",
                className: "I${Model.Name}Behaviours",
                @namespace: "${Project.ProjectName}"
                );
        }
    }
}
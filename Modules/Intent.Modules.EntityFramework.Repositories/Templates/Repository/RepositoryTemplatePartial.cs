﻿using System.Collections.Generic;
using System.Linq;
using Intent.MetaModel.Domain;
using Intent.Modules.Entities.DDD.Templates.RepositoryInterface;
using Intent.Modules.EntityFramework.Repositories.Templates.EntityCompositionVisitor;
using Intent.Modules.EntityFramework.Repositories.Templates.RepositoryInterface;
using Intent.Modules.EntityFramework.Templates.DbContext;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;
using Intent.SoftwareFactory.VisualStudio;

namespace Intent.Modules.EntityFramework.Repositories.Templates.Repository
{
    partial class RepositoryTemplate : IntentRoslynProjectItemTemplateBase<IClass>, ITemplate, IHasTemplateDependencies, IPostTemplateCreation
    {
        public const string Identifier = "Intent.EntityFramework.Repositories.Implementation";
        private ITemplateDependancy _entityStateTemplateDependancy;
        private ITemplateDependancy _entityInterfaceTemplateDependancy;
        private ITemplateDependancy _repositoryInterfaceTemplateDependancy;
        private ITemplateDependancy _dbContextTemplateDependancy;
        private ITemplateDependancy _deleteVisitorTemplateDependancy;

        public RepositoryTemplate(IClass model, IProject project)
            : base(Identifier, project, model)
        {
        }

        public void Created()
        {
            _entityStateTemplateDependancy = TemplateDependancy.OnModel<IClass>(GetMetaData().CustomMetaData["Entity Template Id"], (to) => to.Id == Model.Id);
            _entityInterfaceTemplateDependancy = TemplateDependancy.OnModel<IClass>(GetMetaData().CustomMetaData["Entity Interface Template Id"], (to) => to.Id == Model.Id);
            _repositoryInterfaceTemplateDependancy = TemplateDependancy.OnModel(RepositoryInterfaceTemplate.Identifier, Model);
            _dbContextTemplateDependancy = TemplateDependancy.OnTemplate(DbContextTemplate.Identifier);
            _deleteVisitorTemplateDependancy = TemplateDependancy.OnTemplate(EntityCompositionVisitorTemplate.Identifier);
        }

        public string EntityInterfaceName => Project.FindTemplateInstance<IHasClassDetails>(_entityInterfaceTemplateDependancy)?.ClassName ?? $"I{Model.Name}";

        public string EntityName => Project.FindTemplateInstance<IHasClassDetails>(_entityStateTemplateDependancy)?.ClassName ?? $"{Model.Name}";

        public string RepositoryContractName => Project.FindTemplateInstance<IHasClassDetails>(_repositoryInterfaceTemplateDependancy)?.ClassName ?? $"I{ClassName}";

        public string DbContextName => Project.FindTemplateInstance<IHasClassDetails>(_dbContextTemplateDependancy)?.ClassName ?? $"{Model.Application.Name}DbContext";

        public string DeleteVisitorName => Project.FindTemplateInstance<IHasClassDetails>(_deleteVisitorTemplateDependancy)?.ClassName ?? $"{Model.Application.Name}DeleteVisitor";

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetaData(Id, "1.0"));
        }

        protected override RoslynDefaultFileMetaData DefineRoslynDefaultFileMetaData()
        {
            return new RoslynDefaultFileMetaData(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: $"{Model.Name}Repository",
                fileExtension: "cs",
                defaultLocationInProject: "Repository",
                className: "${Model.Name}Repository",
                @namespace: "${Project.Name}"
                );
        }

        public IEnumerable<ITemplateDependancy> GetTemplateDependencies()
        {
            return new[]
            {
                _entityStateTemplateDependancy,
                _entityInterfaceTemplateDependancy,
                _repositoryInterfaceTemplateDependancy,
                _dbContextTemplateDependancy,
                _deleteVisitorTemplateDependancy,
            };
        }

        public override IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return new[]
                {
                    new NugetPackageInfo("Intent.Framework.EntityFramework", "1.0.0-pre1", null),
                }
                .Union(base.GetNugetDependencies())
                .ToArray();
        }
    }
}

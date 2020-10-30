using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Types.Api;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.ModuleBuilder.Api;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using Intent.Modules.ModuleBuilder.Sql.Api;
using Intent.Modules.ModuleBuilder.Templates.IModSpec;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Sql.Templates.SqlFileTemplatePartial
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class SqlFileTemplatePartial : CSharpTemplateBase<SqlTemplateModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "ModuleBuilder.Sql.Templates.SqlFileTemplatePartial";

        public SqlFileTemplatePartial(IOutputTarget project, SqlTemplateModel model) : base(TemplateId, project, model)
        {
            AddNugetDependency(NugetPackages.IntentCommonSql);
        }

        public IList<string> FolderBaseList => new[] { "Templates" }.Concat(Model.GetFolderPath(false).Where((p, i) => (i == 0 && p.Name != "Templates") || i > 0).Select(x => x.Name)).ToList();
        public string FolderPath => string.Join("/", FolderBaseList);
        public string FolderNamespace => string.Join(".", FolderBaseList);

        public override RoslynMergeConfig ConfigureRoslynMerger()
        {
            return new RoslynMergeConfig(new TemplateMetadata(Id, "1.0"));
        }

        protected override CSharpDefaultFileConfig DefineFileConfig()
        {
            return new CSharpDefaultFileConfig(
                className: $"{Model.Name}",
                @namespace: $"{OutputTarget.GetNamespace()}.{FolderNamespace}.{Model.Name}",
                fileName: $"{Model.Name}Partial",
                relativeLocation: $"{FolderPath}/${Model.Name}");
        }
        
        public override void BeforeTemplateExecution()
        {
            Project.Application.EventDispatcher.Publish(new TemplateRegistrationRequiredEvent(
                modelId: Model.Id,
                templateId: GetTemplateId(),
                templateType: "Sql Template",
                role: GetRole()));
            Project.Application.EventDispatcher.Publish(new ModuleDependencyRequiredEvent(
                moduleId: "Intent.Common.Sql",
                moduleVersion: "3.0.0-beta"));
            if (Model.GetModelType() != null)
            {
                Project.Application.EventDispatcher.Publish(new ModuleDependencyRequiredEvent(
                    moduleId: Model.GetModelType().ParentModule.Name,
                    moduleVersion: Model.GetModelType().ParentModule.Version));
            }
        }

        private string GetRole()
        {
            return Model.GetRole() ?? GetTemplateId();
        }

        public string GetTemplateId()
        {
            return $"{Project.Application.Name}.{FolderNamespace}.{Model.Name}";
        }

        private string GetModelType()
        {
            return Model.GetModelName();
        }
    }
}
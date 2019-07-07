using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Templates;
using Mono.TextTemplating;

namespace Intent.Modules.ModuleBuilder.Templates.Common
{
    public class TemplatePreProcessedFileTemplate : IntentProjectItemTemplateBase<IElement>
    {
        private readonly string _t4TemplateId;
        private readonly string _partialTemplateId;

        public TemplatePreProcessedFileTemplate(
            string templateId,
            IProject project,
            IElement model,
            string t4TemplateId,
            string partialTemplateId)
                : base(templateId, project, model)
        {
            _t4TemplateId = t4TemplateId;
            _partialTemplateId = partialTemplateId;
        }

        public override ITemplateFileConfig DefineDefaultFileMetadata()
        {
            var metadata = new DefaultFileMetadata(
                overwriteBehaviour: OverwriteBehaviour.OnceOff,
                codeGenType: CodeGenType.Basic,
                fileName: "${Model.Name}",
                fileExtension: "cs",
                defaultLocationInProject: "Templates/${Model.Name}");

            metadata.CustomMetadata.Add("Depends On", "${Model.Name}.tt");

            return metadata;
        }

        public override string TransformText()
        {
            var t4TemplateInstance = Project.FindTemplateInstance(_t4TemplateId, Model);
            var partialTemplateInstance = Project.FindTemplateInstance(_partialTemplateId, Model);
            var partialTemplateMetadata = partialTemplateInstance.GetMetadata();
            var templateGenerator = new TemplateGenerator();

            templateGenerator.PreprocessTemplate(
                inputFileName: string.Empty,
                className: partialTemplateMetadata.CustomMetadata["ClassName"],
                classNamespace: partialTemplateMetadata.CustomMetadata["Namespace"],
                inputContent: t4TemplateInstance.RunTemplate(),
                language: out _,
                references: out _,
                outputContent: out var outputContent);

            return outputContent;
        }
    }
}
﻿using Intent.Modules.Common.Plugins;
using Intent.SoftwareFactory;
using Intent.Plugins;
using Intent.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Plugins.FactoryExtensions;

namespace Intent.Modules.OutputManager.FileHeaders
{
    public class FileHeaderOMP : FactoryExtensionBase, ITransformOutput
    {
        private bool _appendHeadersToOnceOffTemplates = true;
        private HeaderAppendBehaviour _unspecifiedBehaviour = HeaderAppendBehaviour.Always;
        private Dictionary<string, HeaderAppendBehaviour> _codeGenTypeMap;

        public const string APPEND_TO_ONCE_OFF = "Append To Once Off";
        public const string APPEND_ALWAYS = "Append Always";
        public const string APPEND_ONCREATE = "Append On Create";

        public FileHeaderOMP()
        {
            _codeGenTypeMap = new Dictionary<string, HeaderAppendBehaviour>();
        }

        public override string Id
        {
            get
            {
                return "Intent.OutputTransformer.FileHeader";
            }
        }

        public override void Configure(IDictionary<string, string> settings)
        {
            base.Configure(settings);
            settings.SetIfSupplied(APPEND_TO_ONCE_OFF, (x) => _appendHeadersToOnceOffTemplates = x, bool.Parse );
            settings.SetIfSupplied(APPEND_ALWAYS, (x) => AddMappings(x, HeaderAppendBehaviour.Always));
            settings.SetIfSupplied(APPEND_ONCREATE, (x) => AddMappings(x, HeaderAppendBehaviour.OnCreate));
        }

        private void AddMappings(string codeTypes, HeaderAppendBehaviour behaviour)
        {
            var types = codeTypes.Split(',');
            foreach (var x in types)
            {
                var s = x.Trim();
                if (!string.IsNullOrWhiteSpace(s) )
                {
                    _codeGenTypeMap[s] = behaviour;
                }
            }
        }

        public void Transform(IOutputFile output)
        {
            if (output.FileMetadata.OverwriteBehaviour == OverwriteBehaviour.OnceOff && _appendHeadersToOnceOffTemplates)
            {
                output.ChangeContent(AppendHeader(output));
                return;
            }

            HeaderAppendBehaviour behaviour;
            if (!_codeGenTypeMap.TryGetValue(output.FileMetadata.CodeGenType , out behaviour))
            {
                behaviour = _unspecifiedBehaviour;
            }

            switch (behaviour)
            {
                case HeaderAppendBehaviour.Always:
                    output.ChangeContent(AppendHeader(output));
                    break;
                case HeaderAppendBehaviour.OnCreate:
                    if (!File.Exists(output.FileMetadata.GetFullLocationPathWithFileName()))
                    {
                        output.ChangeContent(AppendHeader(output));
                    }
                    break;
                case HeaderAppendBehaviour.Never:
                    break;
            }
        }

        private string AppendHeader(IOutputFile output)
        {
            string content = output.Content;
            IFileMetadata fileMetadata = output.FileMetadata;

            string header = GetHeader(output);
            //Deal with XML Declartions <?xml...>
            switch (fileMetadata.FileExtension.ToLower())
            {
                case "xml":
                case "config":
                    if (content.Substring(0, 2) == "<?")
                    {
                        int pos = content.IndexOf(">\r\n");
                        return content.Substring(0, pos + 3) + header + content.Substring(pos + 3);
                    }
                    break;
            }
            if (!string.IsNullOrWhiteSpace(header))
            {
                content = header + content;
            }
            return content;
        }

        private string GetHeader(IOutputFile output)
        {
            string fileExtension = output.FileMetadata.FileExtension;
            IFileMetadata fileMetadata = output.FileMetadata;

            var codeGenTypeDescription = output.FileMetadata.CodeGenType;
            var overwriteBehaviourDescription = output.FileMetadata.OverwriteBehaviour.GetDescription();

            var additionalHeaders = output.Template.GetAllAdditionalHeaderInformation();
            var additionalHeaderInformation = !additionalHeaders.Any()
                ? string.Empty
                : Environment.NewLine + Environment.NewLine + additionalHeaders.Select(x => $" - {x}").Aggregate((x, y) => x + Environment.NewLine + y) + Environment.NewLine;


            var header = $@"
******************************************************************************
   ___       _             _
  |_ _|_ __ | |_ ___ _ __ | |_
   | || '_ \| __/ _ \ '_ \| __|
   | || | | | ||  __/ | | | |_
  |___|_| |_|\__\___|_| |_|\__|

  Gen Type : {codeGenTypeDescription}    {additionalHeaderInformation}
******************************************************************************".TrimStart();

            switch (fileExtension.ToLower())
            {
                // for /*..*/ style comment file extensions
                case "cs":
                case "js":
                case "ts":
                    return $@"/*{header}*/{Environment.NewLine}";
                // for <!--..--> style comment file extensions
                case "xaml":
                case "html":
                case "xml":
                case "config":
                    return $@"<!--{header}*-->{Environment.NewLine}";
                default:
                    return null;
            }
        }
    }
}

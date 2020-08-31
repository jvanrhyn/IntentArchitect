﻿using System.Linq;
using Intent.Modules.Common.TypeScript.Editor;
using Zu.TypeScript.TsTypes;

namespace Intent.Modules.Common.TypeScript.Weaving
{
    public class TypeScriptFileMerger
    {
        private readonly TypeScriptFile _existingFile;
        private readonly TypeScriptFile _outputFile;

        public TypeScriptFileMerger(TypeScriptFile existingFile, TypeScriptFile outputFile)
        {
            _existingFile = existingFile;
            _outputFile = outputFile;
        }

        public string GetMergedFile()
        {
            foreach (var import in _outputFile.Imports())
            {
                if (!_existingFile.ImportExists(import))
                {
                    _existingFile.AddImport(import);
                }
            }

            var existingClasses = _existingFile.ClassDeclarations();
            var outputClasses = _outputFile.ClassDeclarations();

            var toAdd = outputClasses.Except(existingClasses).ToList();
            var toUpdate = existingClasses.Where(x => !x.IsIgnored()).Intersect(outputClasses).ToList();
            var toRemove = existingClasses.Where(x => !x.IsIgnored()).Except(outputClasses).ToList();

            foreach (var @class in toAdd)
            {
                _existingFile.AddClass(@class.GetTextWithComments());
            }

            foreach (var @class in toRemove)
            {
                @class.Remove();
            }

            foreach (var existingClass in toUpdate)
            {
                var outputClass = outputClasses.Single(x => x.Equals(existingClass));
                MergeClasses(existingClass, outputClass);
            }

            return _existingFile.GetSource();
        }

        private static void MergeClasses(TypeScriptClass existingClass, TypeScriptClass outputClass)
        {
            if (!existingClass.IsMerged() &&
                (!existingClass.HasConstructor() || !existingClass.Constructor().IsIgnored()) &&
                existingClass.Methods().All(x => !x.IsIgnored()) &&
                existingClass.Properties().All(x => !x.IsIgnored()))
            {
                existingClass.ReplaceWith(outputClass.GetTextWithComments());
                return;
            }

            // TODO: Decorators
            MergeConstructor(existingClass, outputClass);
            MergeProperties(existingClass, outputClass);
            MergeMethods(existingClass, outputClass);
        }

        private static void MergeConstructor(TypeScriptClass existingClass, TypeScriptClass outputClass)
        {
            if (existingClass.HasConstructor())
            {
                var constructor = existingClass.Constructor();
                if (constructor.IsIgnored())
                {
                    return;
                }
                if (outputClass.HasConstructor())
                {
                    constructor.ReplaceWith(outputClass.Constructor().GetTextWithComments());
                }
                else if (!existingClass.IsMerged())
                {
                    constructor.Remove();
                }
            }
            else if (outputClass.HasConstructor())
            {
                existingClass.AddConstructor(outputClass.Constructor().GetTextWithComments());
            }
        }

        private static void MergeProperties(TypeScriptClass existingClass, TypeScriptClass outputClass)
        {
            var existingProperties = existingClass.Properties();
            var outputProperties = outputClass.Properties();
            var toAdd = outputProperties.Except(existingProperties).ToList();
            var toUpdate = existingProperties.Where(x => !x.IsIgnored()).Intersect(outputProperties).ToList();
            var toRemove = existingProperties.Where(x => !x.IsIgnored()).Except(outputProperties).ToList();

            foreach (var property in toAdd)
            {
                existingClass.AddProperty(property.GetTextWithComments());
            }
            foreach (var property in toUpdate)
            {
                var outputMethod = outputClass.Properties().Single(x => x.Equals(property));
                property.ReplaceWith(outputMethod.GetTextWithComments());
            }

            foreach (var property in toRemove)
            {
                if (!existingClass.IsMerged() || property.IsManaged())
                {
                    property.Remove();
                }
            }
        }

        private static void MergeMethods(TypeScriptClass existingClass, TypeScriptClass outputClass)
        {
            var existingMethods = existingClass.Methods();
            var outputMethods = outputClass.Methods();
            var toAdd = outputMethods.Except(existingMethods).ToList();
            var toUpdate = existingMethods.Where(x => !x.IsIgnored()).Intersect(outputMethods).ToList();
            var toRemove = existingMethods.Where(x => !x.IsIgnored()).Except(outputMethods).ToList();

            foreach (var method in toAdd)
            {
                existingClass.AddMethod(method.GetTextWithComments());
            }

            foreach (var method in toUpdate)
            {
                var outputMethod = outputClass.Methods().Single(x => x.Equals(method));
                method.ReplaceWith(outputMethod.GetTextWithComments());
            }

            foreach (var method in toRemove)
            {
                if (!existingClass.IsMerged() || method.IsManaged())
                {
                    method.Remove();
                }
            }
        }
    }
}
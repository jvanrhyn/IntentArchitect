﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Templates;
using IApplication = Intent.Engine.IApplication;
using IClassTypeSource = Intent.Modules.Common.TypeResolution.IClassTypeSource;

namespace Intent.Modules.Common.Templates
{
    public class CSharpTypeSource : IClassTypeSource
    {
        private readonly Func<ITypeReference, string> _execute;
        private static readonly IList<ITemplateDependency> _templateDependencies = new List<ITemplateDependency>();

        internal CSharpTypeSource(Func<ITypeReference, string> execute)
        {
            _execute = execute;
        }

        public static IClassTypeSource InProject(IProject project, string templateId, string collectionFormat = "IEnumerable<{0}>")
        {
            return new CSharpTypeSource((typeInfo) =>
            {
                var typeName = FullTypeNameInProject(project, templateId, typeInfo);
                if (!string.IsNullOrWhiteSpace(typeName) && typeInfo.IsCollection)
                {
                    return string.Format(collectionFormat, typeName);;
                }
                return typeName;
            });
        }

        private static string FullTypeNameInProject(IProject project, string templateId, ITypeReference typeInfo)
        {
            var templateInstance = GetTemplateInstance(project, templateId, typeInfo);

            return templateInstance != null ? 
                templateInstance.FullTypeName() + (typeInfo.GenericTypeParameters.Any() 
                    ? $"<{string.Join(", ", typeInfo.GenericTypeParameters.Select(x => FullTypeNameInProject(project, templateId, x)))}>" 
                    : "") 
                : null;
        }

        public static IClassTypeSource InApplication(IApplication application, string templateId, string collectionType = nameof(IEnumerable))
        {
            return new CSharpTypeSource((typeInfo) =>
            {
                if (typeInfo.IsCollection)
                {
                    return $"{collectionType}<{FullTypeNameInApplication(application, templateId, typeInfo)}>";
                }
                return FullTypeNameInApplication(application, templateId, typeInfo);
            });
        }

        private static string FullTypeNameInApplication(IApplication application, string templateId, ITypeReference typeInfo)
        {
            var templateInstance = application.FindTemplateInstance<IHasClassDetails>(TemplateDependency.OnModel<IMetadataModel>(templateId, (x) => x.Id == typeInfo.Id));
            if (templateInstance != null)
            {
                _templateDependencies.Add(TemplateDependency.OnModel<IMetadataModel>(templateId, (x) => x.Id == typeInfo.Id));
            }
            return templateInstance?.FullTypeName();
        }

        public string GetClassType(ITypeReference typeInfo)
        {
            return _execute(typeInfo);
        }

        public IEnumerable<ITemplateDependency> GetTemplateDependencies()
        {
            return _templateDependencies;
        }

        private static IHasClassDetails GetTemplateInstance(IProject project, string templateId, ITypeReference typeInfo)
        {
            var templateInstance = project.FindTemplateInstance<IHasClassDetails>(TemplateDependency.OnModel<IMetadataModel>(templateId, (x) => x.Id == typeInfo.Id));
            if (templateInstance != null)
            {
                _templateDependencies.Add(TemplateDependency.OnModel<IMetadataModel>(templateId, (x) => x.Id == typeInfo.Id));
            }

            return templateInstance;
        }
    }
}
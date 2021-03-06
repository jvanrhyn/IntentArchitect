﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intent.Metadata.Models;
using Intent.Modules.Common.TypeResolution;
using Intent.Templates;

namespace Intent.Modules.Common.Types
{
    internal class NoResolverRegisteredTypeResolverFactory : Contracts.ITypeResolverFactory
    {
        public string Name
        {
            get
            {
                return "No Type Resolver Registered";
            }
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }

        public IEnumerable<string> SupportedFileTypes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ITypeResolver Create()
        {
            return new NoResolverRegisteredTypeResolver();
        }

        internal class NoResolverRegisteredTypeResolver : ITypeResolver
        {
            public string DefaultCollectionFormat { get; set; } = "{0}";

            public void AddClassTypeSource(Func<ITypeReference, string> typeLookup)
            {
                throw new NotImplementedException();
            }

            public void AddClassTypeSource(ITypeSource typeSource)
            {
                throw new NotImplementedException();
            }

            public void AddClassTypeSource(ITypeSource typeSource, string contextName)
            {
                throw new NotImplementedException();
            }

            public IResolvedTypeInfo Get(ITypeReference typeInfo)
            {
                if (typeInfo == null)
                    return new ResolvedTypeInfo(string.Empty, false, null);
                return new ResolvedTypeInfo(typeInfo.Element.Name, false, null);
            }

            public IResolvedTypeInfo Get(ITypeReference typeInfo, string collectionFormat)
            {
                if (typeInfo == null)
                    return new ResolvedTypeInfo(string.Empty, false, null);
                return new ResolvedTypeInfo(string.Format(collectionFormat, typeInfo.Element.Name), false, null);
            }

            public IResolvedTypeInfo Get(ICanBeReferencedType element)
            {
                if (element == null)
                    return new ResolvedTypeInfo(string.Empty, false, null);
                return new ResolvedTypeInfo(element.Name, false, null);
            }

            public IResolvedTypeInfo Get(ICanBeReferencedType element, string collectionFormat)
            {
                if (element == null)
                    return new ResolvedTypeInfo(string.Empty, false, null);
                return new ResolvedTypeInfo(string.Format(collectionFormat, element.Name), false, null);
            }

            public ITypeResolverContext InContext(string contextName)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<ITemplateDependency> GetTemplateDependencies()
            {
                return new List<ITemplateDependency>();
            }
        }
    }
}

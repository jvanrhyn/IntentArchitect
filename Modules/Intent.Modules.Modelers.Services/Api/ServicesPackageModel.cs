using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common.Types.Api;
using Intent.RoslynWeaver.Attributes;
using EnumModel = Intent.Modelers.Services.Api.EnumModel;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiPackageModel", Version = "1.0")]

namespace Intent.Modules.Modelers.Services.Api
{
    [IntentManaged(Mode.Merge)]
    public class ServicesPackageModel : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Services Package";
        public const string SpecializationTypeId = "df45eaf6-9202-4c25-8dd5-677e9ba1e906";

        [IntentManaged(Mode.Ignore)]
        public ServicesPackageModel(IPackage package)
        {
            if (!SpecializationType.Equals(package.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from package with specialization type '{package.SpecializationType}'. Must be of type '{SpecializationType}'");
            }

            UnderlyingPackage = package;
        }

        public IPackage UnderlyingPackage { get; }
        public string Id => UnderlyingPackage.Id;
        public string Name => UnderlyingPackage.Name;
        public IEnumerable<IStereotype> Stereotypes => UnderlyingPackage.Stereotypes;
        public string FileLocation => UnderlyingPackage.FileLocation;

        public IList<DTOModel> DTOs => UnderlyingPackage.ChildElements
            .Where(x => x.SpecializationType == DTOModel.SpecializationType)
            .Select(x => new DTOModel(x))
            .ToList();

        public IList<EnumModel> Enums => UnderlyingPackage.ChildElements
            .Where(x => x.SpecializationType == EnumModel.SpecializationType)
            .Select(x => new EnumModel(x))
            .ToList();

        public IList<FolderModel> Folders => UnderlyingPackage.ChildElements
            .Where(x => x.SpecializationType == FolderModel.SpecializationType)
            .Select(x => new FolderModel(x))
            .ToList();

        public IList<ServiceModel> Services => UnderlyingPackage.ChildElements
            .Where(x => x.SpecializationType == ServiceModel.SpecializationType)
            .Select(x => new ServiceModel(x))
            .ToList();

        public IList<TypeDefinitionModel> Types => UnderlyingPackage.ChildElements
            .Where(x => x.SpecializationType == TypeDefinitionModel.SpecializationType)
            .Select(x => new TypeDefinitionModel(x))
            .ToList();
    }
}
﻿using System.Collections.Generic;
using Intent.Modules.AspNet.WebApi.Templates.OwinWebApiConfig;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;
using Intent.SoftwareFactory.VisualStudio;

namespace Intent.Modules.AspNet.Swashbuckle.Decorators
{
    public class SwashbuckleWebApiConfigTemplateDecorator : WebApiConfigTemplateDecoratorBase, IHasNugetDependencies, IDeclareUsings
    {
        private readonly IApplication _application;

        public SwashbuckleWebApiConfigTemplateDecorator(IApplication application)
        {
            _application = application;
        }

        public const string Id = "Intent.AspNet.Swashbuckle.WebApiConfigDecorator";

        public override IEnumerable<string> Configure()
        {
            return new[]
            {
                "ConfigureSwashbuckle(config);",
            };
        }

        public override string Methods()
        {
            return $@"
        //[IntentManaged(Mode.Ignore)] // Uncomment to take control of this method.
        private static void ConfigureSwashbuckle(HttpConfiguration config)
        {{
            config.EnableSwagger(c => c.SingleApiVersion(""v1"", ""{_application.ApplicationName} API""))
                .EnableSwaggerUi();
        }}";
        }

        public IEnumerable<string> DeclareUsings()
        {
            return new[]
            {
                "Swashbuckle.Application",
            };
        }

        public IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            return new[] 
            {
                NugetPackages.SwashbuckleAspNetCore,
            };
        }
    }
}
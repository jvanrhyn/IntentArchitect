using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.Engine;
using Intent.Modules.Common.IdentityServer4.Decorators;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;


[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.IdentityServer4.Selfhost.Templates.Startup
{
    [IntentManaged(Mode.Merge, Signature = Mode.Merge)]
    partial class Startup : CSharpTemplateBase<object>, IHasDecorators<StartupDecorator>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "IdentityServer4.Selfhost.Startup";

        private readonly List<StartupDecorator> _decorators = new List<StartupDecorator>();

        public Startup(IOutputTarget outputTarget, object model) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency(NugetPackages.IdentityServer4);
        }

        protected override CSharpDefaultFileConfig DefineFileConfig()
        {
            return new CSharpDefaultFileConfig(
                className: $"Startup",
                @namespace: $"{OutputTarget.GetNamespace()}");
        }

        public string GetClientsConfiguration()
        {
            return $"{GetTemplateClassName(IdentityConfig.IdentityConfig.TemplateId)}.Clients";
        }

        public string GetApiResourcesConfiguration()
        {
            return $"{GetTemplateClassName(IdentityConfig.IdentityConfig.TemplateId)}.ApiResources";
        }

        public string GetScopesConfiguration()
        {
            return $"{GetTemplateClassName(IdentityConfig.IdentityConfig.TemplateId)}.Scopes";
        }

        public string GetIdentityResourcesConfiguration()
        {
            return $"{GetTemplateClassName(IdentityConfig.IdentityConfig.TemplateId)}.IdentityResources";
        }

        public string GetIdentityServerServices(int tabSubIndents)
        {
            var indents = string.Join("    ", Enumerable.Range(0, tabSubIndents).Select(s => string.Empty));
            var sb = new StringBuilder();
            sb.AppendLine("services.AddIdentityServer()");

            AddFluentCall(sb, indents, $"AddInMemoryClients({GetClientsConfiguration()})");
            AddFluentCall(sb, indents, $"AddInMemoryApiResources({GetApiResourcesConfiguration()})");
            AddFluentCall(sb, indents, $"AddInMemoryApiScopes({GetScopesConfiguration()})");
            AddFluentCall(sb, indents, $"AddInMemoryIdentityResources({GetIdentityResourcesConfiguration()})");

            GetDecorators()
                .SelectMany(s => s.GetServicesConfigurationStatements())
                .ToList()
                .ForEach(x => AddFluentCall(sb, indents, x));

            sb.Append(indents).AppendLine(";");
            return sb.ToString();
        }

        private static void AddFluentCall(StringBuilder sb, string indents, string statement)
        {
            sb.Append(indents).Append(".").AppendLine(statement);
        }

        public void AddDecorator(StartupDecorator decorator)
        {
            _decorators.Add(decorator);
        }

        public IEnumerable<StartupDecorator> GetDecorators()
        {
            return _decorators;
        }
    }
}
﻿using Intent.Modules.AspNet.WebApi.Templates.OwinWebApiConfig;
using Intent.Modules.Common.Registrations;
using Intent.SoftwareFactory.Engine;

namespace Intent.Modules.AspNet.WebApi.Decorators
{
    public class ExceptionHandlerFilterWebApiConfigDecoratorRegistration : DecoratorRegistration<WebApiConfigTemplateDecoratorBase>
    {
        public override string DecoratorId => ExceptionHandlerFilterWebApiConfigDecorator.DecoratorId;

        public override object CreateDecoratorInstance(IApplication application)
        {
            return new ExceptionHandlerFilterWebApiConfigDecorator();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Intent.Metadata.Models;

namespace Intent.Modules.Angular.Api
{
    public interface IModuleModel : IHasStereotypes, IMetadataModel
    {
        string Name { get; }

        IElementApplication Application { get; }

        IEnumerable<IComponentModel> Components { get; }

        IEnumerable<IServiceProxyModel> ServiceProxies { get; }

        IEnumerable<IModuleDTOModel> ModelDefinitions { get; }

        string Comment { get; }
    }
}

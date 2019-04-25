using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using ModuleTesting.IdentityServer4Host.Application;


[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations", Version = "1.0")]

namespace ModuleTesting.IdentityServer4Host.Application.ServiceImplementation
{
    public class SimpleTest : ISimpleTest
    {

        public SimpleTest()
        {
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public async Task OperationA()
        {
            throw new NotImplementedException("Write your implementation for this service here...");
        }

        public void Dispose()
        {
        }
    }
}
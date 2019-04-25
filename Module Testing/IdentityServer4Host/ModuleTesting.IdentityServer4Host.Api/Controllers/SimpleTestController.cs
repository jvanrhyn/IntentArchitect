using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleTesting.IdentityServer4Host.Application;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.WebApi.Controller", Version = "1.0")]

namespace ModuleTesting.IdentityServer4Host.Api.Controllers
{
    [Route("api/[controller]")]
    public class SimpleTestController : Controller
    {
        private readonly ISimpleTest _appService;

        public SimpleTestController(ISimpleTest appService
            )
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpPost("operationa")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> OperationA()
        {
            var tso = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };

            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, tso, TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _appService.OperationA();

                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

            return Ok();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            //dispose all resources
            _appService.Dispose();
        }

    }
}
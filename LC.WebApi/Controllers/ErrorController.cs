using LC.Core.Shared.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LC.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            Response.StatusCode = 500;

            var errorId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

            return new ErrorResponse() { Id = errorId };
        }
    }
}

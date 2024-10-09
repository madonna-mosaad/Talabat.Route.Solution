using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    [Route("Errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult ValidationError(int code)
        {
            if (code == 404)
            {
                return NotFound(new ApiResponse(404));

            }
            else if (code == 401)
            {
                return Unauthorized(new ApiResponse(401));
            }
            else
            {
                return StatusCode(code);
            }
        }

    }
}

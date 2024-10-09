using Core.Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Layer.Data.Context;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreDbContext _storeDbContext;

        public BuggyController(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        //not found data
        [HttpGet("NotFound")]
        public ActionResult notFound()
        {
            Product product = _storeDbContext.products.Find(100);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(product);
        }
        //badrequest
        [HttpGet("BadRequest")]
        public ActionResult badRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        //Unauthorized
        [HttpGet("Unauthorized")]
        public ActionResult unauthorized()
        {
            return Unauthorized(new ApiResponse(401));
        }
        //validationError
        [HttpGet("Any/{id}")]
        public ActionResult any(int id)
        {
            return Ok();
        }
        //Server Error
        [HttpGet("ServerError")]
        public ActionResult sever()
        {
            Product product = _storeDbContext.products.Find(100);
            //null referance error
            var p = product.Price;
            return Ok(product);
        }
        //Not Found EndPoint=>will go to Errors
    }
}

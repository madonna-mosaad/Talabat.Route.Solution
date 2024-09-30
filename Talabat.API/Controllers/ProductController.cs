using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.API.Controllers
{
    public class ProductController : TalabatBaseController
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductController(IGenericRepository<Product> genericRepository) 
        {
            _genericRepository = genericRepository;
        }
        //to arrive to this end point use => {BaseUrl}/api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products =await _genericRepository.GetAllAsync();
            return Ok(products);
        }
        //to arrive to this end point use => {BaseUrl}/api/Products/id_value
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product =await _genericRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new {Message ="Not Found",StatusCode=404});
            }
            return Ok(product);
        }
    }
}

using AutoMapper;
using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Core.Layer.Specifications.SpecificationClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTO;

namespace Talabat.API.Controllers
{
    public class ProductController : TalabatBaseController
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> genericRepository,IMapper mapper) 
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        //to arrive to this end point use => {BaseUrl}/api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var spec = new ProductsSpecificationValues();
            var products =await _genericRepository.GetAllWithSpecAsync(spec);
            var productsDTo = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(productsDTo);
        }
        //to arrive to this end point use => {BaseUrl}/api/Products/id_value
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            var spec = new ProductsSpecificationValues(p=>p.Id==id);
            var product =await _genericRepository.GetByIdWithSpecAsync(spec);
            if (product == null)
            {
                return NotFound(new {Message ="Not Found",StatusCode=404});
            }
            var productDTO= _mapper.Map<Product,ProductDTO>(product);
            return Ok(productDTO);
        }
    }
}

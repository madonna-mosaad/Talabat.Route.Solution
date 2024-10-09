using AutoMapper;
using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Core.Layer.Specifications.SpecificationClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTO;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    public class ProductController : TalabatBaseController
    {
        private readonly IGenericRepository<Product> _ProductGenericRepository;
        private readonly IGenericRepository<ProductBrand> _brandGenericRepository;
        private readonly IGenericRepository<ProductCategory> _categoryGenericRepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productGenericRepository,IGenericRepository<ProductBrand> brandGenericRepository,IGenericRepository<ProductCategory> categoryGenericRepository,IMapper mapper) 
        {
            _ProductGenericRepository = productGenericRepository;
            _brandGenericRepository = brandGenericRepository;
            _categoryGenericRepository = categoryGenericRepository;
            _mapper = mapper;
        }
        //to arrive to this end point use => {BaseUrl}/api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var spec = new ProductsSpecificationValues();
            var products =await _ProductGenericRepository.GetAllWithSpecAsync(spec);
            var productsDTo = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(productsDTo);
        }
        //to arrive to this end point use => {BaseUrl}/api/Products/id_value
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse),404)]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int id)
        {
            var spec = new ProductsSpecificationValues(p=>p.Id==id);
            var product =await _ProductGenericRepository.GetByIdWithSpecAsync(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var productDTO= _mapper.Map<Product,ProductDTO>(product);
            return Ok(productDTO);
        }
        [HttpGet("GetBrands")]
        public async Task<ActionResult<ProductBrand>> GetBrands()
        {
            var brands =await _brandGenericRepository.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("GetCategories")]
        public async Task<ActionResult<ProductCategory>> GetCategories()
        {
            var categories =await _categoryGenericRepository.GetAllAsync();
            return Ok(categories);
        }
    }
}

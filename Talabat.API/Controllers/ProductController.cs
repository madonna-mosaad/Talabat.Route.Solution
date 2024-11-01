using AutoMapper;
using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Core.Layer.Specifications.SpecificationClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTO;
using Talabat.API.Helpers;
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
        [Cached(300)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProductsAsync([FromQuery]ProductGetAllParameters productGetAllParameters)
        {
            var spec = new ProductsSpecificationValues(productGetAllParameters);
            var products =await _ProductGenericRepository.GetAllWithSpecAsync(spec);
            var productsDTo = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
            var specCount=new ProductsSpecificationValues(productGetAllParameters.Search,productGetAllParameters.BrandId,productGetAllParameters.CategoryId);
            int count = await _ProductGenericRepository.CountAsync(specCount);
            return Ok(new PaginationResponse<ProductDTO>(productGetAllParameters.PageSize,productGetAllParameters.PageIndex,count,productsDTo));
        }
        //to arrive to this end point use => {BaseUrl}/api/Products/id_value
        [Cached(300)]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse),404)]
        [Authorize(AuthenticationSchemes ="Bearer")]
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
        [Cached(300)]
        [HttpGet("GetBrands")]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands =await _brandGenericRepository.GetAllAsync();
            return Ok(brands);
        }
        [Cached(300)]
        [HttpGet("GetCategories")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategories()
        {
            var categories =await _categoryGenericRepository.GetAllAsync();
            return Ok(categories);
        }
    }
}

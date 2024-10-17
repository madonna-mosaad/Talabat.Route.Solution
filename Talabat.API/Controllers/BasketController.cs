using AutoMapper;
using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Talabat.API.DTO;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    public class BasketController : TalabatBaseController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDTO>> GetBasketAsync(string id)
        {
            var basket = await _basketRepository.GetAsync(id);
            if (basket == null)
            {
                return new CustomerBasketDTO(id) ;
            }
            var Basket= _mapper.Map<CustomerBasket,CustomerBasketDTO> (basket);
            return Ok(Basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> SetBasketAsync(CustomerBasketDTO customerBasketDTO)
        {
            var customerBasket= _mapper.Map<CustomerBasketDTO,CustomerBasket> (customerBasketDTO);
            var basket = await _basketRepository.SetAsync(customerBasket);
            if (basket == null)
            {
                return BadRequest(new ApiResponse(400));
            }
           
            return Ok(basket);
        }
        [HttpDelete("{id}")]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteAsync(id);    
        }
    }
}

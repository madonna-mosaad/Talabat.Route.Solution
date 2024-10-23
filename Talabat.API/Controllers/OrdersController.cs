using AutoMapper;
using Core.Layer.Order_Aggregate;
using Core.Layer.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTO;
using Talabat.API.Response;

namespace Talabat.API.Controllers
{
    public class OrdersController : TalabatBaseController
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrdersController(IOrderServices orderServices,IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromQuery] OrderParams orderParams) 
        {
            var address = _mapper.Map<AddressParams,Address>(orderParams.address);
            var Order =await  _orderServices.CreateOrder(orderParams.BuyerEmail, orderParams.BasketId, orderParams.deliveryMethodId, address);
            if (Order is null) return BadRequest(new ApiResponse(400));
            return Ok(Order);
        }

    }
}

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
        public async Task<ActionResult<OrderDTO>> CreateOrder( OrderParams orderParams) 
        {
            var address = _mapper.Map<AddressParams,Address>(orderParams.Address);
            var Order =await  _orderServices.CreateOrder(orderParams.BuyerEmail, orderParams.BasketId, orderParams.DeliveryMethodId, address);
            if (Order is null) return BadRequest(new ApiResponse(400));
            return Ok(_mapper.Map<Order, OrderDTO>(Order));
        }
        [HttpGet("GetOrdersForUser")]
        public async Task<ActionResult<IReadOnlyList<OrderDTO>>> GetOrdersForUser(string email)
        {
            var orders =await _orderServices.GetOrdersToSpecificUser(email);
            if (orders is null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map< IReadOnlyList<Order>, IReadOnlyList<OrderDTO>>(orders));
        }
        [HttpGet("GetOrderByIdForUser")]
        public async Task<ActionResult<OrderDTO>> GetOrderByIdForUser(string email,int id)
        {
            var order = await _orderServices.GetSpecificOrderByIdToSpecificUser(email,id);
            if (order is null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Order,OrderDTO>(order));
        }
    }
}

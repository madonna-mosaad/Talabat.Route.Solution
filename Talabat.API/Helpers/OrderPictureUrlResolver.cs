using AutoMapper;
using Core.Layer.Order_Aggregate;
using Talabat.API.DTO;

namespace Talabat.API.Helpers
{
    public class OrderPictureUrlResolver : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration _configuration;

        public OrderPictureUrlResolver(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.productOrderItem.ProductUrl))
            {
                return string.Empty;
            }
            return $"{_configuration["BaseUrl"]}/{source.productOrderItem.ProductUrl}";
        }
    }
}

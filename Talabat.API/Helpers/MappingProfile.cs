using AutoMapper;
using Core.Layer.Models;

using Talabat.API.DTO;

namespace Talabat.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDTO>().ForMember(d=>d.BrandName,o=>o.MapFrom(s=>s.Brand.Name))
                                            .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                                            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductPictureUrlResolver>());
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
            CreateMap< AddressParams, Core.Layer.Order_Aggregate.Address>().ReverseMap();
            CreateMap<Address,AddressDTO>().ReverseMap();
            CreateMap<Core.Layer.Order_Aggregate.Order, OrderDTO>()
                .ForMember(d => d.DeliveryMethodName, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.DeliveryMethodPrice, o => o.MapFrom(s => s.DeliveryMethod.Cost))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
            CreateMap<Core.Layer.Order_Aggregate.OrderItem, OrderItemDTO>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.productOrderItem.ProductName))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.productOrderItem.ProductId))
                .ForMember(d => d.ProductUrl, o => o.MapFrom<OrderPictureUrlResolver>());

        }
    }
}

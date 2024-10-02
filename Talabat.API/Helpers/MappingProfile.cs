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
        }
    }
}

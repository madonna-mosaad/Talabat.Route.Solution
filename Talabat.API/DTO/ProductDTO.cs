using Core.Layer.Models;

namespace Talabat.API.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //same name as Table in DB so doesnot need data annotation or fluent API 
        public int ProductBrandId { get; set; }
        public string BrandName { get; set; }
        //same name as Table in DB so doesnot need data annotation or fluent API 
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

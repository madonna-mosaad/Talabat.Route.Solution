using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class Product :ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //same name as Table in DB so doesnot need data annotation or fluent API 
        public int ProductBrandId { get; set; }
        public ProductBrand Brand { get; set; }
        //same name as Table in DB so doesnot need data annotation or fluent API 
        public int ProductCategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}

using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Specifications.SpecificationClasses
{
    //to each Model make class like this to give the values to specifications
    public class ProductsSpecificationValues :BaseSpecifications<Product>
    {
        //each new query form i create new constractor

        //query = .where().OrderBy()orOrderByDesc().Skip().Take().Include().Include()
        //or    = .OrderBy()orOrderByDesc().Skip().Take().Include().Include()   =>  when base(p=>True) da ely hyro7 ll where fkanha msh mogoda
        //or    = .Skip().Take().Include().Include() =>if sort = null or empty
        //or    = .Include().Include() =>if productGetAllParameters.PageSize==0&&productGetAllParameters.PageIndex==0
        public ProductsSpecificationValues(ProductGetAllParameters productGetAllParameters) :base(p=>
            (!productGetAllParameters.BrandId.HasValue|| p.ProductBrandId==productGetAllParameters.BrandId.Value)
               &&(!productGetAllParameters.CategoryId.HasValue||p.ProductCategoryId==productGetAllParameters.CategoryId.Value)
               &&(string.IsNullOrEmpty(productGetAllParameters.Search)||p.Name.Contains(productGetAllParameters.Search)))
        {
            Includes.Add( p => p.Brand);
            Includes.Add(p=>p.Category);
            //this switch make me do method 3lshan el orderby takhod el value bta3 el param mno
            if (!string.IsNullOrEmpty(productGetAllParameters.Sort))
            {
                switch (productGetAllParameters.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            if (productGetAllParameters.PageSize!=0&&productGetAllParameters.PageIndex!=0)
            {
                AddPagination((productGetAllParameters.PageIndex - 1) * productGetAllParameters.PageSize, productGetAllParameters.PageSize);
            }
        }
        //query = .where().Include().Include()
        public ProductsSpecificationValues(Expression<Func<Product, bool>> expression) : base(expression)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
        //query= .where().count() => 3mlt kda 3lshan mohm elfilteration bs f el total count
        public ProductsSpecificationValues(string? search,int? brandId,int? categoryId) : base(p =>
            (!brandId.HasValue || p.ProductBrandId == brandId.Value)
               && (!categoryId.HasValue || p.ProductCategoryId == categoryId.Value)
               && (string.IsNullOrEmpty(search) || p.Name.Contains(search)))
        {
            
        }
    }
}

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
        public ProductsSpecificationValues() :base()
        {
            Includes.Add( p => p.Brand);
            Includes.Add(p=>p.Category);
        }
        public ProductsSpecificationValues(Expression<Func<Product, bool>> expression) : base(expression)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}

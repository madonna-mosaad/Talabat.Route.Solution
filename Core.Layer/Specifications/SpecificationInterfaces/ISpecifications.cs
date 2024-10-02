using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Specifications.SpecificationInterfaces
{
    //non-implemented code to specifications that i will give in Method that create the query
    public interface ISpecifications<T> where T : ModelBase
    {
        //the expression that put in where (ex: p=>p.Id==id)
        //Expression<Delegate>
        public Expression<Func<T,bool>> Critria {  get; set; }
        //other specifications is any thing like include , take , skip,orderBy
        //collection of Include because i can have more than one include in my query
        public List<Expression<Func<T,Object>>> Includes {  get; set; }
    }
}

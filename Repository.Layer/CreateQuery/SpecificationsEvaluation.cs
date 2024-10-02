using Core.Layer.Models;
using Core.Layer.Specifications.SpecificationInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.CreateQuery
{
    internal static class SpecificationsEvaluation<T> where T : ModelBase
    {
        //parmeters are 1-the sequence(_dbcontext.Products(all products data that its type is Collection))
                      //2-the specifications
        //the return is collection (IQueryable because will happen filteration in where)
        public  static IQueryable<T> GetQuery(IQueryable<T> TableData ,ISpecifications<T> specifications)
        {
            var query = TableData;
            if(specifications.Critria != null)
            {
                query=query.Where(specifications.Critria);
            }
            query = specifications.Includes.Aggregate(query, (Cur_Query, Include_spec) => Cur_Query.Include(Include_spec));
            return query;
        }
    }
}

using Core.Layer.Models;
using Core.Layer.Specifications.SpecificationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Specifications.SpecificationClasses
{
    public class BaseSpecifications<T> : ISpecifications<T> where T : ModelBase
    {
        //ban be null in GetAll
        public Expression<Func<T, bool>>? Critria { get; set ; }
        public List<Expression<Func<T, object>>> Includes { get ; set; } = new List<Expression<Func<T, object>>>();
        //constructor to GetAll that doesnot have where
        public BaseSpecifications()
        {
            //Critria is null
        }
        //constructor to GetBy... that have where
        public BaseSpecifications(Expression<Func<T,bool>> expression)
        {
            Critria = expression;
        }
    }
    
}

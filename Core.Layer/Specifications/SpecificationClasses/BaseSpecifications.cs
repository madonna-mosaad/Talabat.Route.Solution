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
        public Expression<Func<T, bool>>? Critria { get; set ; }//initialize is null
        public List<Expression<Func<T, object>>> Includes { get ; set; } = new List<Expression<Func<T, object>>>();//make initialize only to collections
        public Expression<Func<T, object>> OrderBy { get ; set; }//initialize is null
        public Expression<Func<T,Object>> OrderByDescending { get ; set; }//initialize is null
        public int Skip { get ; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; } = false;

        public BaseSpecifications()//chain to it when query donot have where
        {
            //Critria is null
        }

        public BaseSpecifications(Expression<Func<T,bool>> expression)//chain to it when query have where
        {
            Critria = expression;
        }
        //make method to put its parameter value in orderby because i will do switch in ProductSpecificationValues to send the value
        private protected void AddOrderBy(Expression<Func<T,Object>> orderBy)//call it in ProductSpecificationValues if i want query has orderby()
        {
            OrderBy = orderBy;
        }
        private protected void AddOrderByDesc(Expression<Func<T,Object>> orderByDesc)//call it in ProductSpecificationValues if i want query has orderby()
        {
            OrderByDescending = orderByDesc;
        }
        private protected void AddPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Take = take;
            Skip= skip;
        }
    }
    
}

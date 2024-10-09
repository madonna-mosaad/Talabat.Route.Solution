using Core.Layer.Models;
using Core.Layer.Specifications.SpecificationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.RepositoriesInterface
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        //add , update and delete in Dashboard because it related to admin role

        //if product
        public Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> specifications);
        public Task<T> GetByIdWithSpecAsync(ISpecifications<T> specifications);    

    }
}

using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Core.Layer.Specifications.SpecificationClasses;
using Core.Layer.Specifications.SpecificationInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Layer.CreateQuery;
using Repository.Layer.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly StoreDbContext _storeDbContext;

        public GenericRepository(StoreDbContext storeDbContext) 
        {
            _storeDbContext = storeDbContext;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
    
            return await _storeDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           
            return await _storeDbContext.Set<T>().FindAsync(id);
        }

        //if product
        //take specifications only because the sequence(TableData) will get it from DB
        //specifications against Interface not concrete class because we donot know the type of T(it is generic)
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> specifications)
        {
            return await SpecificationsEvaluation<T>.GetQuery(_storeDbContext.Set<T>(),specifications).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> specifications)
        {
            return await SpecificationsEvaluation<T>.GetQuery(_storeDbContext.Set<T>() , specifications).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecifications<T> specifications)
        {
            return await SpecificationsEvaluation<T>.GetQuery(_storeDbContext.Set<T>(), specifications).CountAsync();
        }

        public void Delete(T entity)
        {
            _storeDbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            _storeDbContext.Update(entity);
        }

        public void Add(T entity)
        {
            _storeDbContext.Add(entity);
        }
    }
}

using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IEnumerable<T>) await _storeDbContext.Set<Product>().Include(p=>p.Brand).Include(p=>p.Category).ToListAsync();
            }
            return await _storeDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await _storeDbContext.Set<Product>().Where(p => p.Id == id).Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync() as T;
            }
            return await _storeDbContext.Set<T>().FindAsync(id);
        }
    }
}

using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Repository.Layer.Data.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _storeDbContext;
        private Hashtable Repositories;

        public UnitOfWork(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            Repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await _storeDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
           _storeDbContext.Dispose();
        }

        public IGenericRepository<T> RepositoryCreate<T>() where T : ModelBase
        {
            var key = typeof(T).Name;
            if (!Repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_storeDbContext);
                Repositories.Add(key, repository);
            }
            return Repositories[key] as IGenericRepository<T>;
        }
    }
}

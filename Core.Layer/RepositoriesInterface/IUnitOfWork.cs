using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.RepositoriesInterface
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<T> RepositoryCreate<T>() where T:ModelBase;
        public Task<int> CompleteAsync();
       

    }
}

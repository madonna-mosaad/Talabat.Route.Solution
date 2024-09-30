using Core.Layer.Models;
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

    }
}

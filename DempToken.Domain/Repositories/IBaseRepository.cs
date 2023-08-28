using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DempToken.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> Get();

        public Task<T> GetById(int id);

        public Task<int> Post(T obj);

        public Task<int> Put(T obj);

        public Task<int> Delete(int id);
    }
}

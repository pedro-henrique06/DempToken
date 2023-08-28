using DempToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DempToken.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetByLogin(string? userName, string? password);
    }
}

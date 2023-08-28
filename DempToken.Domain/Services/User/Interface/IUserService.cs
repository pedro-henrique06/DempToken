using DempToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DempToken.Domain
{
    public interface IUserService : IBaseService<User>
    {
        public Task<User> GetByLogin(string? userName, string? password);
    }
}

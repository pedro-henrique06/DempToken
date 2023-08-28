using DempToken.Domain;
using DempToken.Domain.Repositories;
using DempToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DempToken.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userUserRepository;

        public UserService(IUserRepository userUserRepository)
        {
            _userUserRepository = userUserRepository;
        }

        public async Task<IEnumerable<User>> Get()
        {

            var result = await _userUserRepository.Get();
            return result;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _userUserRepository.GetById(id);
            return result;
        }

        public async Task<int> Post(User obj)
        {
            var result = await _userUserRepository.Post(obj);
            return result;
        }

        public async Task<int> Put(User obj)
        {
            var result = await _userUserRepository.Put(obj);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var result = await _userUserRepository.Delete(id);
            return result;

        }

        public async Task<User> GetByLogin(string? email, string? password)
        {
            var result = await _userUserRepository.GetByLogin(email, password);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repositories.Abstraction
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers(CancellationToken token = default);
        public Task<User> GetUser(int x, CancellationToken token = default);
        public Task<User> GetUserByMail(string mail, CancellationToken token = default);
        public Task<bool> AddUser(User user, CancellationToken token);
        public Task<bool> UpdateUser(User user, CancellationToken token);
    }
}

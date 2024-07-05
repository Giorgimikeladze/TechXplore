using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Abstraction;
using Domain.Models;
using Persistance.Context;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context)
        {
            
        }

        public async  Task<bool> AddUser(User user, CancellationToken token)
        {
            return await base.Create(user, token).ConfigureAwait(false);
        }

        public async Task<User> GetUserByMail(string mail, CancellationToken token = default)
        {
            return await base.FindByCondition(x=>x.Email==mail,token)
                .ConfigureAwait(false);
        }

        public async Task<List<User>> GetUsers(CancellationToken token = default)
        {
            return await base.GetAll(token).ConfigureAwait(false);  
        }

        public async Task<User> GetUser(int x, CancellationToken token = default)
        {
            return await base.GetEntity(x, token).ConfigureAwait(false);
        }

        public async Task<bool> UpdateUser(User user, CancellationToken token)
        {
            return await base.Update(user, token).ConfigureAwait(false);
        }
    }
}

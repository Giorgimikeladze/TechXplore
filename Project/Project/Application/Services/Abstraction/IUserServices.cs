using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Models.User;
using Domain.Models;
using Domain.Models.Abstract;

namespace Application.Services.Abstraction
{
    public interface IUserServices
    {
        public Task<bool> Register(UserRequestModel user,CancellationToken token=default);
        public Task<string> Login(UserLoginModel user, CancellationToken token = default);
        public Task<bool> Update(UserRequestModel user, CancellationToken token = default);
        Task<List<Claim>> LoginForMVC(UserLoginModel model, CancellationToken token = default);
    }
}

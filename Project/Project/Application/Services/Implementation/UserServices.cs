using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Models.User;
using Application.Repositories.Abstraction;
using Application.Services.Abstraction;
using Domain.Models;
using Mapster;
using Microsoft.Extensions.Options;

namespace Application.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repo;
        private readonly IOptions<JwtSettings> _jwt;
        public UserServices(IUserRepository repo, IOptions<JwtSettings> jwt)
        {
            _repo= repo;    
            _jwt= jwt;
        }

        public async Task<string> Login(UserLoginModel model, CancellationToken token = default)
        {
            var user=await _repo.GetUserByMail(model.Email,token).ConfigureAwait(false);
            if (user == null)
            {
                throw new Exception("Such User Does not Exists");
            }
            var tempPassword=Methods.Methods.PasswordHashFunction(model.Password);
            if (user.Password == tempPassword)
            {
                var key = _jwt.Value.Key;
                return Methods.Methods.CreateToken(key, user);
            }
            
            throw new Exception("Invalid Value"); 
        }

        public async Task<List<Claim>> LoginForMVC(UserLoginModel model, CancellationToken token = default)
        {
            var user = await _repo.GetUserByMail(model.Email, token)
                .ConfigureAwait(false);

            var hashpass = Methods.Methods.PasswordHashFunction(model.Password);
            if (user == null)
            {
                throw new Exception("Such user does not exists");
            }
            else if (user.Password != hashpass)
            {
                throw new Exception("Password is not correct");
            }
            var claims = new List<Claim>
            {
             new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
             new Claim(ClaimTypes.Role,user.Role.ToString()),
             new Claim(ClaimTypes.Email,user.Email)

            };
            return claims;
        }

        public async Task<bool> Register(UserRequestModel user,CancellationToken token=default)
        {
            if (await _repo.GetUserByMail(user.Email) != null)
            {
                throw new Exception("Such User Already Exists");
            }
            var temp = user.Adapt<User>();
            temp.Password = Methods.Methods.PasswordHashFunction(user.Password);
            return await _repo.AddUser(temp, token).ConfigureAwait(false);
        }

        public async Task<bool> Update(UserRequestModel user, CancellationToken token = default)
        {
            return await _repo.UpdateUser(user.Adapt<User>(), token).ConfigureAwait(false);   
        }
    }
}

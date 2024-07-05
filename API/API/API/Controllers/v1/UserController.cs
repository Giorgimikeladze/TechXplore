using Application.Models.User;
using Application.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices user)
        {
            _userService = user;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<bool> Register(UserRequestModel model, CancellationToken token = default)
        {

            if (ModelState.IsValid)
            {
                return await _userService.Register(model, token);
            }
            throw new Exception("User Is not valid");

        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<string> Login(UserLoginModel model, CancellationToken token)
        {

            if (ModelState.IsValid)
            {

                return await _userService.Login(model, token).ConfigureAwait(false);
            }
            throw new Exception("Invalid User");
        }

        [HttpPut]
        public async Task<bool> UpdateUser(UserRequestModel model, CancellationToken token) {
            if (ModelState.IsValid)
            {
                return await _userService.Update(model, token).ConfigureAwait(false);

            }
            throw new Exception("Invalid Object");    
        }

    }
}

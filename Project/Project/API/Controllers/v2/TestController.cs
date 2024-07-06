
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v2
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<int> GetNumber(CancellationToken token = default)
        {
            return 1;
        }
    }
}

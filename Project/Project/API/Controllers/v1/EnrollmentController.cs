
using Application.Services.Abstraction;
using Domain.Models.AssotiativeEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentServices _services;

        public EnrollmentController(IEnrollmentServices services)
        {
            _services = services;
        }
        [Authorize(Roles ="Customer")]
        [HttpPut]
        public async Task<bool> UpdateScore(Enrollment enrollmetn, CancellationToken token = default) { 
            
            return await _services.UpdateEnrollemtn(enrollmetn,token).ConfigureAwait(false);
        
        }


        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<bool> Enroll(Enrollment model, CancellationToken token = default) {             
            return await _services.Enroll(model,token).ConfigureAwait(false); 
            

        }


    }
}

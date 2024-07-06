
using Application.Models.Quizs;
using Application.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizServices _services;

        public QuizController(IQuizServices services)
        {
            _services = services;
        }

        [AllowAnonymous]
        [HttpGet("GetAllQuizes")]
        public async Task<List<QuizViewModel>> GetAllQuiz(CancellationToken token = default) { 
            return await _services.GetActiveQuizes(token).ConfigureAwait(false);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<bool>CreateQuiz(QuizRequestModel model,CancellationToken token = default)
        {
            if (ModelState.IsValid)
            {
                return await _services.CreateQuiz(model, token).ConfigureAwait(false);

            }
            throw new Exception("Invalid Object");    

        } 

    }
}

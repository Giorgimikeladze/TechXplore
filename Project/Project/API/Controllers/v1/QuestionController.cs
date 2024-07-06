
using Application.Models.Question;
using Application.Services.Abstraction;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices _questionSerice;

        public QuestionController(IQuestionServices questionSerice)
        {
            _questionSerice = questionSerice;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<bool> CreateQuestion(QuestionRequestModel question, CancellationToken token = default) {

            if (ModelState.IsValid)
            {
                return await _questionSerice.CreateQuestion(question, token).ConfigureAwait(false);
            }
            throw new Exception("Invalid Object");


        }
        [Authorize(Roles = "Customer")]
        [HttpGet]

        public async Task<List<QuestionResponseModel>> GetQuestions(int id, CancellationToken token = default) { 
            
            return await _questionSerice.GetQuestions(id, token).ConfigureAwait(false); 

        }

    }
}

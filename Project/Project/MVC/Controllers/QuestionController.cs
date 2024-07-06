using Application.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionServices questionServices;

        public QuestionController(IQuestionServices questionServices)
        {
            this.questionServices = questionServices;
        }

        public async Task<IActionResult> GetQuestions(int id, CancellationToken token = default) { 
            
            var questions= await questionServices.GetQuestions(id).ConfigureAwait(false);
            return View(questions);
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}

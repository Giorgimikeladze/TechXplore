using Application.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizServices quizServices;

        public QuizController(IQuizServices quizServices)
        {
            this.quizServices = quizServices;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetQuizes(CancellationToken token = default) {

            var quizes=await quizServices.GetActiveQuizes(token);
            return View(quizes);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

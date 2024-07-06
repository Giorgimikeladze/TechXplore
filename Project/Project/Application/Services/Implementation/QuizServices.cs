using Application.Models.Quizs;
using Application.Repositories.Abstraction;
using Application.Services.Abstraction;
using Domain.Models;
using Mapster;

namespace Application.Services.Implementation
{
    public class QuizServices : IQuizServices
    {
        private readonly IQuizRepository _quizRepository;

        public QuizServices(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<bool> CreateQuiz(QuizRequestModel quiz, CancellationToken token = default)
        {
            return await _quizRepository.CerateQuiz(quiz.Adapt<Quiz>(), token).ConfigureAwait(false);
        }

        public async Task<List<QuizViewModel>> GetActiveQuizes(CancellationToken token = default)
        {
            var list= await _quizRepository.GetActiveQuizes(token).ConfigureAwait(false);
            return list
                .Adapt<List<QuizViewModel>>();
        }
    }
}

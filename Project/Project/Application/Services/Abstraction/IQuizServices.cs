using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Quizs;
using Domain.Models;

namespace Application.Services.Abstraction
{
    public interface IQuizServices
    {
        public Task<List<QuizViewModel>> GetActiveQuizes(CancellationToken token = default);
        public Task<bool> CreateQuiz(QuizRequestModel quiz, CancellationToken token = default);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repositories.Abstraction
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetQuizQuestions(int quizid,CancellationToken token=default);
        Task<bool> CreateQuestion(Question question, CancellationToken token = default);
    }
}

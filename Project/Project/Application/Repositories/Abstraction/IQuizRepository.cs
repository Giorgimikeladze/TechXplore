using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repositories.Abstraction
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetActiveQuizes(CancellationToken token = default);
        Task<bool> CerateQuiz(Quiz quiz, CancellationToken token = default);

    }
}

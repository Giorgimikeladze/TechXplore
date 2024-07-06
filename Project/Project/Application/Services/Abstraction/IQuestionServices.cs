using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Application.Models.Question;
using Domain.Models;

namespace Application.Services.Abstraction
{
    public interface IQuestionServices
    {
        Task<bool> CreateQuestion(QuestionRequestModel question, CancellationToken token = default);
        Task<List<QuestionResponseModel>> GetQuestions(int id, CancellationToken token = default);


    }
}

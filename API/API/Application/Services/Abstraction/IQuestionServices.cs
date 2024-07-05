using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Question;
using Domain.Models;

namespace Application.Services.Abstraction
{
    public interface IQuestionServices
    {
        Task<bool> CreateQuestion(QuestionRequestModel question, CancellationToken token = default);


    }
}

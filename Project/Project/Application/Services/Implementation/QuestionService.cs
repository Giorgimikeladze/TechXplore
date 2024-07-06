using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Question;
using Application.Repositories.Abstraction;
using Application.Services.Abstraction;
using Domain.Models;
using Mapster;

namespace Application.Services.Implementation
{
    public class QuestionService:IQuestionServices
    {
        private readonly IQuestionRepository _repo;

        public QuestionService(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateQuestion(QuestionRequestModel question, CancellationToken token = default)
        {
            return await _repo.CreateQuestion(question.Adapt<Question>(), token).ConfigureAwait(false);
        }

        public async Task<List<QuestionResponseModel>> GetQuestions(int id, CancellationToken token = default)
        {
            var list=await _repo.GetQuizQuestions(id, token).ConfigureAwait(false);
            return list.Adapt<List<QuestionResponseModel>>();
        }
    }
}

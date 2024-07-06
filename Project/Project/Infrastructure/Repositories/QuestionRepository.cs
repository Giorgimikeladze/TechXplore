using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Abstraction;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Infrastructure.Repositories
{
    public class QuestionRepository :BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> CreateQuestion(Question question, CancellationToken token = default)
        {
            return await base.Create(question).ConfigureAwait(false);
        }

        public async Task<List<Question>> GetQuizQuestions(int quizid, CancellationToken token = default)
        {
            return await base.FindAllByCondition(x=>x.QuizId==quizid) .ConfigureAwait(false);
        }
    }
}

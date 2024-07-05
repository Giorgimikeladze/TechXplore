using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Abstraction;
using Domain.Enuns;
using Domain.Models;
using Persistance.Context;

namespace Infrastructure.Repositories
{
    public class QuizRepository :BaseRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(ApplicationDbContext context):base(context) 
        {
                
        }

        public async Task<bool> CerateQuiz(Quiz quiz, CancellationToken token = default)
        {
            return await base.Create(quiz,token).ConfigureAwait(false);
        }

        public async Task<List<Quiz>> GetActiveQuizes(CancellationToken token = default)
        {
            return await base.FindAllByCondition(x=>x.Status==Status.Upcomming).ConfigureAwait(false);  
        }
    }
}

using Application.Repositories.Abstraction;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration) {

            #region EF Core
            services.AddDbContext<ApplicationDbContext>(options
                    => options.UseSqlServer(configuration.GetConnectionString("Default")));
            #endregion

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

        }
    }
}

using Application.Services.Abstraction;
using Application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class ServiceDependencies
    {
        public static void InjectServices(this IServiceCollection services) {

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IQuizServices, QuizServices>();
            services.AddScoped<IQuestionServices, QuestionService>();
            services.AddScoped<IEnrollmentServices, EnrollmentServices>();
        }
    }
}

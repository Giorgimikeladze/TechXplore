using System.Net.NetworkInformation;
using Domain.Models;
using Domain.Models.AssotiativeEntities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User>Users { get; set; }
        public DbSet<Quiz>Quizes { get; set; }
        public DbSet<Question>Questions { get; set; }
        public DbSet<Enrollment>UserQuizzes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

           
            //// Seeding data for Quizzes
            //modelBuilder.Entity<Quiz>().HasData(
            //    new Quiz { Id = 1, Title = "General Knowledge Quiz", Description = "A quiz about general knowledge", StartDate = DateTime.Now, Score = 0 }
            //);

            //// Seeding data for Questions
            //modelBuilder.Entity<Question>().HasData(
            //    new Question { Id = 1, Quest = "What is the capital of France?", Answer1 = "Paris", Answer2 = "London", Answer3 = "Berlin", Answer4 = "Madrid", ReadAnswer = "Paris", QuizId = 1 },
            //    new Question { Id = 2, Quest = "What is 2 + 2?", Answer1 = "3", Answer2 = "4", Answer3 = "5", Answer4 = "6", ReadAnswer = "4", QuizId = 1 }
            //);

            //// Seeding data for UserQuizzes
            //modelBuilder.Entity<UserQuiz>().HasData(
            //    new UserQuiz { Id = 1, UserId = 1, QuizId = 1 }
            //);
        }
    }
}

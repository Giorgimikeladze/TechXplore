using Domain.Enuns;
using Domain.Models.Abstract;
using Domain.Models.AssotiativeEntities;

namespace Domain.Models
{
    public class Quiz:Entity
    {
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }=DateTime.Now;
        public Status Status { get; set; }=Status.Upcomming;
        public List<Question> Questions { get; set; } 
        public List<Enrollment>UserQuizzes { get; set; }
    }
}

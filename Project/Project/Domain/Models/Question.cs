using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Abstract;

namespace Domain.Models
{
    public class Question:Entity
    {
        public string Quest { get; set; }=string.Empty;
        public string Answer1 { get; set; } = string.Empty;
        public string Answer2 { get; set; } = string.Empty;
        public string Answer3 { get; set; } = string.Empty;
        public string Answer4 { get; set; } = string.Empty;
        public string ReadAnswer { get; set; } = string.Empty;
        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
    }
}

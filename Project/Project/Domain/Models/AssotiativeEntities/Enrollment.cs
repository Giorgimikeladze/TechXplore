using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Abstract;

namespace Domain.Models.AssotiativeEntities
{
    public class Enrollment:Entity
    {

        public bool IsTaking { get; set; } = false;
        public bool IsOver { get; set; } = false;
        public double TimeToComplite { get; set; } = 0.0;

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        public int Score { get; set; } = 0;
    }

}

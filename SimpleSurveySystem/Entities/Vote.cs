using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Entities
{
    public class Vote
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public Option Option { get; set; }
        public int OptionId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }

    }
}

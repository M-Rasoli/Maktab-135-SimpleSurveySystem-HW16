using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Entities
{
    public class UserSurvey
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

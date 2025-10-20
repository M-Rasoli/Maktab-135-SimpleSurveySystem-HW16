using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Entities
{
    public class Options
    {
        public int Id { get; set; }
        public int OptionNumber { get; set; }
        public string Text { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public List<Vote> Votes { get; set; } = new List<Vote>();
        public DateTime CreatedAt { get; set; } = new DateTime();
        
    }
}

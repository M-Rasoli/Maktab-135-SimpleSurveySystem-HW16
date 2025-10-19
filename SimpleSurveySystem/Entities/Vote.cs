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
        public Options Options { get; set; }
        public int OptionId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

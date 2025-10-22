using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.DTOs
{
    public class CreateVoteDto
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
    }
}

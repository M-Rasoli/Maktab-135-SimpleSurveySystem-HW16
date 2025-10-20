using SimpleSurveySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.DTOs
{
    public class CreateNewQuestionForSurveyDto
    {
        public int SurveyId { get; set; }
        public string QuestionTitle { get; set; }
        public List<CreateNewOptionsForQuestionDto> Options { get; set; }
    }
}

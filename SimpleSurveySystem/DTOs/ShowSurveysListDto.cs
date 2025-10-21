using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleSurveySystem.DTOs
{
    public class ShowSurveysListDto
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public int NumberOfQuestions { get; set; }
        public int TotalNumberOfVotes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.DTOs
{
    public class ShowSurveysDetailWithIdDto
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public int NumberParticipatingUsers { get; set; }
        public int TotalVotes { get; set; }
    }
}

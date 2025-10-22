using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.DTOs
{
    public class GetOptionsWithVotesDetailDto
    {
        public int OptionNumber { get; set; }
        public string OptionText { get; set; }
        public int NumberOfVotes { get; set; }
        public float PercentageOfVotes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public List<Options> Options { get; set; } = new List<Options>();
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public List<Vote> Votes { get; set; } = new List<Vote>();


        //void SetOptions(List<Options> options)
        //{
        //    if (options.Count == 4)
        //    {
        //        Options = options;
        //    }
        //}
    }
}

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


        //void SetOptions(List<Options> options)
        //{
        //    if (options.Count == 4)
        //    {
        //        Options = options;
        //    }
        //}
    }
}

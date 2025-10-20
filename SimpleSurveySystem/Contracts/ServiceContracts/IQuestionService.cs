using SimpleSurveySystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Contracts.ServiceContracts
{
    public interface IQuestionService
    {
        int AddNewQuestion(CreateNewQuestionForSurveyDto newQuestion);
    }
}

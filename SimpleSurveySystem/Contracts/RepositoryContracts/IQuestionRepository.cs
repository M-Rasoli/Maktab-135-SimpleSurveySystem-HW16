using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;

namespace SimpleSurveySystem.Contracts.RepositoryContracts
{
    public interface IQuestionRepository
    {
        int AddNewQuestion(Question newQuestion);
        List<ShowSurveyQuestionAndOptionsDto> GetOptionsOfQuestion(GetOptionsForQuestionWithPaginationDto getOptionsForQuestion);
        string GetQuestionTitle(int questionId);
        int GetFirstQuestionOfSurvey(int surveyId);
        int GetLastQuestionOfSurvey(int surveyId);
    }
}

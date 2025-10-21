using SimpleSurveySystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Contracts.ServiceContracts
{
    public interface ISurveyService
    {
        List<ShowSurveysListDto> GetSurveysList();
        List<ShowSurveysListDto> GetSurveysListForNormalUsers();
        List<ShowSurveysDetailWithIdDto> GetSurveyWithId(int surveyId);
        List<ShowParticipatingUsersDto> GetParticipatingUsersList(int surveyId);
        int CreateNewSurvey(string surveyTitle);
        bool SurveyExist(int surveyId);
    }
}

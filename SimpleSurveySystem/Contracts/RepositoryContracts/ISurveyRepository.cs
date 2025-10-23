using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;

namespace SimpleSurveySystem.Contracts.RepositoryContracts
{
    public interface ISurveyRepository
    {
        int CreateNewSurvey(CreateNewSurveyDto newSurvey);
        bool SurveyExist(int surveyId);
        List<ShowSurveysListDto> GetSurveysList();
        List<ShowSurveysListDto> GetSurveysListForNormalUsers();
        List<ShowSurveysDetailWithIdDto> GetSurveyWithId(int surveyId);
        List<ShowParticipatingUsersDto> GetParticipatingUsersList(int surveyId);
        int DeleteSurvey(int surveyId);
        bool CheckIfSurveyHasVotes(int surveyId);
    }
}

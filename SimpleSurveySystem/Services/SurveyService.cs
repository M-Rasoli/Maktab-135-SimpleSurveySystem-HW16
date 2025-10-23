using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;
using SimpleSurveySystem.DTOs;

namespace SimpleSurveySystem.Services
{
    public class SurveyService(ISurveyRepository surveyRepository) : ISurveyService
    {
        public List<ShowSurveysDetailWithIdDto> GetSurveyWithId(int surveyId)
        {
            if (!surveyRepository.SurveyExist(surveyId))
            {
                throw new Exception("Invalid Survey ID.");
            }
            return surveyRepository.GetSurveyWithId(surveyId);
        }

        public List<ShowSurveysListDto> GetSurveysList()
        {
            return surveyRepository.GetSurveysList();
        }

        public List<ShowParticipatingUsersDto> GetParticipatingUsersList(int surveyId)
        {
            return surveyRepository.GetParticipatingUsersList(surveyId);
        }

        public int CreateNewSurvey(string surveyTitle)
        {
            CreateNewSurveyDto survey = new CreateNewSurveyDto()
            {
                Title = surveyTitle
            };
            return surveyRepository.CreateNewSurvey(survey);
        }

        public bool SurveyExist(int surveyId)
        {
            return surveyRepository.SurveyExist(surveyId);
        }

        public List<ShowSurveysListDto> GetSurveysListForNormalUsers()
        {
            return surveyRepository.GetSurveysListForNormalUsers();
        }

        public int DeleteSurvey(int surveyId)
        {
            if (surveyRepository.SurveyExist(surveyId))
            {
                if (surveyRepository.CheckIfSurveyHasVotes(surveyId))
                {
                    return surveyRepository.DeleteSurvey(surveyId);
                }
                else
                {
                    throw new Exception("You cannot delete a survey that has no votes.");
                }
            }
            else
            {
                throw new Exception("Invalid survey ID");
            }
        }
    }
}

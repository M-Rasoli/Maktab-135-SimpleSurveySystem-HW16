using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;

namespace SimpleSurveySystem.Services
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public bool CheckIfUserAlreadyParticipateInTheSurvey(int surveyId, int userId)
        {
            return _userRepository.CheckIfUserAlreadyParticipateInTheSurvey(surveyId, userId);
        }
    }
}

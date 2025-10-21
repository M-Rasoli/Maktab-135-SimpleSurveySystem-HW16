using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Contracts.ServiceContracts
{
    public interface IUserService
    {
        bool CheckIfUserAlreadyParticipateInTheSurvey(int surveyId, int userId);
    }
}

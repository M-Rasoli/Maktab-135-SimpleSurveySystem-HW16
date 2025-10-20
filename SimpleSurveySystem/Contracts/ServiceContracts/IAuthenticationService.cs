using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Contracts.ServiceContracts
{
    public interface IAuthenticationService
    {
        string Login(string userName, string password);
        string Register(string userName, string password);
        bool CheckIfUserNameAlreadyExist(string userName);
        bool IsPasswordValid(string password);
    }
}

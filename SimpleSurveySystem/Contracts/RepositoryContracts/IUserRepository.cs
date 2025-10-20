using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Contracts.RepositoryContracts
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);
        string AddNewUser(CreateUserDto newUser);
        bool CheckIfUserNameAlreadyExist(string userName);
    }
}

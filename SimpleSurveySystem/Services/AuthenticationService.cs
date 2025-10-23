using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SimpleSurveySystem.Services
{
    public class AuthenticationService(IUserRepository _userRepository) : IAuthenticationService
    {
        public bool CheckIfUserNameAlreadyExist(string userName)
        {
            if (_userRepository.CheckIfUserNameAlreadyExist(userName))
            {
                throw new Exception("User Name Already Exist");
            }

            return true;
        }

        public bool IsPasswordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 3)
            {
                throw new Exception("Invalid Password");
            }

            return true;
        }

        public string Login(string userName, string password)
        {
            var user = _userRepository.GetUserByUserName(userName);
            if (user != null)
            {
                if (user.Password == password)
                {
                    Session.LoggedInUser = user;
                    return user.Username;
                }
            }
            throw new Exception("Username Or Password is Wrong");
        }


        public string Register(string userName, string password)
        {
            CheckIfUserNameAlreadyExist(userName);
            IsPasswordValid(password);
            CreateUserDto user = new CreateUserDto()
            {
                UserName = userName,
                Password = password,
                Role = RoleEnum.NormalUSer
            };
            return _userRepository.AddNewUser(user);
        }
    }
}

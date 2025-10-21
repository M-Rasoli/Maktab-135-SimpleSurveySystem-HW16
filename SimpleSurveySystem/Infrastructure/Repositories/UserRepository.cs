using Microsoft.EntityFrameworkCore;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;
using SimpleSurveySystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public string AddNewUser(CreateUserDto newUser)
        {
            User user = new User()
            {
                Username = newUser.UserName,
                Password = newUser.Password,
                Role = RoleEnum.NormalUSer
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id.ToString();
        }

        public bool CheckIfUserAlreadyParticipateInTheSurvey(int surveyId, int userId)
        {
            return _context.UserSurveyrs.Any(us => us.SurveyId == surveyId && us.UserId == userId);
        }

        public bool CheckIfUserNameAlreadyExist(string userName)
        {
            return _context.Users.Any(u => u.Username.ToUpper() == userName.ToUpper());
        }

        public bool CheckUserIdExist(int userId)
        {
            return _context.Users.Any(u => u.Id == userId && u.Role == RoleEnum.NormalUSer);
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.Username.ToUpper() == userName.ToUpper());
        }
    }
}

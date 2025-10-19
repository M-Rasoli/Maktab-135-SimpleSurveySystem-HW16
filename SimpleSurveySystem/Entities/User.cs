using SimpleSurveySystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UsernName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public List<UserSurvey> UserSurveys { get; set; } = new List<UserSurvey>();
        public List<Vote> Votes { get; set; } = new List<Vote>();
        public DateTime CreatedAt { get; set; } = new DateTime();

        //void SetPassword(string password)
        //{
        //    if (password.Length > 3)
        //    {
        //        Password = password;
        //    }
        //}
    }
}

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
        public List<Survey> Surveys { get; set; } = new List<Survey>();
        public List<Vote> Votes { get; set; } = new List<Vote>();

        //void SetPassword(string password)
        //{
        //    if (password.Length > 3)
        //    {
        //        Password = password;
        //    }
        //}
    }
}

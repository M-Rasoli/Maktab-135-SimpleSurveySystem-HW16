using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;

namespace SimpleSurveySystem.Infrastructure.Repositories
{
    public class SurveyRepository(AppDbContext _context) : ISurveyRepository
    {
        public int CreateNewSurvey(CreateNewSurveyDto newSurvey)
        {
            Survey survey = new Survey()
            {
                Title = newSurvey.Title
            };
            _context.Surveys.Add(survey);
            _context.SaveChanges();
            return survey.Id;

        }
    }
}

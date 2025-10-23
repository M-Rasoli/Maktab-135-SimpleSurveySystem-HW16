using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public List<ShowSurveysDetailWithIdDto> GetSurveyWithId(int surveyId)
        {
            return _context.Surveys
                .AsNoTracking()
                .Where(s => s.Id == surveyId)
                .Select(s => new ShowSurveysDetailWithIdDto
                {
                    SurveyId = s.Id,
                    Title = s.Title,
                    NumberParticipatingUsers = s.Votes
                        .Select(v => v.UserId)
                        .Distinct()
                        .Count(),
                    TotalVotes = s.Votes.Count()
                })
                .ToList();

            //return _context.Votes
            //    .AsNoTracking()
            //    .Where(v => v.SurveyId == surveyId)
            //    .GroupBy(v => new { v.SurveyId, v.Survey.Title })
            //    .Select(g => new ShowSurveysDetailWithIdDto
            //    {
            //        SurveyId = g.Key.SurveyId,
            //        Title = g.Key.Title,
            //        NumberParticipatingUsers = g.Select(v => v.UserId).Distinct().Count(),
            //        TotalVotes = g.Count()
            //    })
            //    .ToList();
        }

        public List<ShowSurveysListDto> GetSurveysList()
        {
            return _context.Surveys.AsNoTracking().Select(x => new ShowSurveysListDto()
            {
                SurveyId = x.Id,
                Title = x.Title,
                NumberOfQuestions = x.Questions.Count,
                TotalNumberOfVotes = x.Votes.Count
            }).ToList();
        }

        public bool SurveyExist(int surveyId)
        {
            return _context.Surveys.Any(s => s.Id == surveyId);
        }

        public List<ShowParticipatingUsersDto> GetParticipatingUsersList(int surveyId)
        {
            return _context.Votes.AsNoTracking().Where(us => us.SurveyId == surveyId)
                .Select(x => new ShowParticipatingUsersDto()
                {
                    UserId = x.UserId,
                    UserName = x.User.Username
                }).Distinct().ToList();
        }

        public List<ShowSurveysListDto> GetSurveysListForNormalUsers()
        {
            return _context.Surveys.AsNoTracking().Where(s => s.Questions.Count > 0)
                .Select(x => new ShowSurveysListDto()
            {
                SurveyId = x.Id,
                Title = x.Title,
                NumberOfQuestions = x.Questions.Count,
                TotalNumberOfVotes = x.Votes.Count
            }).ToList();
        }

        public int DeleteSurvey(int surveyId)
        {
            var survey = _context.Surveys.FirstOrDefault(s => s.Id == surveyId);
            _context.Surveys.Remove(survey);
            //_context.SaveChanges();
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
            return survey.Id;
        }

        public bool CheckIfSurveyHasVotes(int surveyId)
        {
            return _context.Votes.Any(v => v.SurveyId == surveyId);
        }
    }
}

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
    internal class QuestionRepository(AppDbContext _context) : IQuestionRepository
    {
        public int AddNewQuestion(Question newQuestion)
        {
            _context.Questions.Add(newQuestion);
            _context.SaveChanges();

            return newQuestion.Id;
        }

        public int GetFirstQuestionOfSurvey(int surveyId)
        {
            return _context.Questions.AsNoTracking().FirstOrDefault(q => q.SurveyId == surveyId).Id;
        }

        public int GetLastQuestionOfSurvey(int surveyId)
        {
            return _context.Questions.AsNoTracking().OrderByDescending(q => q.Id).FirstOrDefault(q => q.SurveyId == surveyId).Id;
        }

        public List<ShowSurveyQuestionAndOptionsDto> GetOptionsOfQuestion(GetOptionsForQuestionWithPaginationDto getOptionsForQuestion)
        {
            return _context.Options.Where(o => o.QuestionId == getOptionsForQuestion.QuestionId)
                .Select(x => new ShowSurveyQuestionAndOptionsDto
                {
                    OptionNumber = x.OptionNumber,
                    OptionText = x.Text
                }).ToList();
        }

        public string GetQuestionTitle(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == questionId).QuestionTitle;
        }
    }
}

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
    }
}

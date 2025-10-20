using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;

namespace SimpleSurveySystem.Contracts.RepositoryContracts
{
    public interface IQuestionRepository
    {
        int AddNewQuestion(Question newQuestion);
    }
}

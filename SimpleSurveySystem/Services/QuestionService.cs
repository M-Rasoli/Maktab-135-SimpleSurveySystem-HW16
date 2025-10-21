using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Services
{
    public class QuestionService(IQuestionRepository _questionRepository,ISurveyRepository _surveyRepository) : IQuestionService
    {
        public int AddNewQuestion(CreateNewQuestionForSurveyDto newQuestion)
        {
            if (!_surveyRepository.SurveyExist(newQuestion.SurveyId))
            {
                throw new Exception("Invalid Survey Id .");
            }
            Question question = new Question()
            {
                SurveyId = newQuestion.SurveyId,
                QuestionTitle = newQuestion.QuestionTitle,
                Options = newQuestion.Options
                    .Select(option => new Options()
                    {
                        OptionNumber = option.OptionNumber,
                        Text = option.Text

                    }).ToList()
            };
            //foreach (var option in newQuestion.Options)
            //{
            //    question.Options.Add(new Options()
            //    {
            //        OptionNumber = option.OptionNumber,
            //        Text = option.Text
            //    });
            //}
            return _questionRepository.AddNewQuestion(question);

        }
    }
}

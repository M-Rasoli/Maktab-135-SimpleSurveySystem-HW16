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
    public class QuestionService(IQuestionRepository _questionRepository) : IQuestionService
    {
        public int AddNewQuestion(CreateNewQuestionForSurveyDto newQuestion)
        {
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

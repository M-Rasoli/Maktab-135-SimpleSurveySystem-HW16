using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.Contracts.ServiceContracts;
using SimpleSurveySystem.DTOs;

namespace SimpleSurveySystem.Services
{
    public class OptionService(IOptionRepository _optionRepository) : IOptionService
    {
        public List<GetOptionsWithVotesDetailDto> GetOptionsWithVotesDetail(int surveyId, int pageNumber, int pageSize)
        {
            return _optionRepository.GetOptionsWithVotesDetail(surveyId,  pageNumber,  pageSize);
        }
    }
}

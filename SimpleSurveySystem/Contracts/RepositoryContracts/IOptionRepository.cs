using SimpleSurveySystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleSurveySystem.Contracts.RepositoryContracts
{
    public interface IOptionRepository
    {
        List<GetOptionsWithVotesDetailDto> GetOptionsWithVotesDetail(int surveyId, int pageNumber, int pageSize);
    }
}

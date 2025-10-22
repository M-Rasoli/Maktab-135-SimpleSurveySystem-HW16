using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.DTOs;

namespace SimpleSurveySystem.Infrastructure.Repositories
{
    public class OptionRepository(AppDbContext _context) : IOptionRepository
    {
        public List<GetOptionsWithVotesDetailDto> GetOptionsWithVotesDetail(int surveyId, int pageNumber, int pageSize)
        {
            return _context.Options.AsNoTracking()
                .Where(o => o.Question.SurveyId == surveyId)
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize)
                .Select(x => new GetOptionsWithVotesDetailDto()
                {
                    OptionNumber = x.OptionNumber,
                    OptionText = x.Text,
                    NumberOfVotes = x.Votes.Count,
                    PercentageOfVotes = x.Votes.Count == 0 ? 0 : (float)Math.Round((x.Votes.Count * 100.0f),2)
                }).OrderByDescending(v => v.NumberOfVotes)
                .ThenBy(v => v.OptionNumber)
                .ToList();
        }
    }
}

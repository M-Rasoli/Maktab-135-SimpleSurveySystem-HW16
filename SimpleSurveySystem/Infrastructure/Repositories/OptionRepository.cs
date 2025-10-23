using Microsoft.EntityFrameworkCore;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Infrastructure.Repositories
{
    public class OptionRepository(AppDbContext _context) : IOptionRepository
    {
        public List<GetOptionsWithVotesDetailDto> GetOptionsWithVotesDetail(int surveyId, int pageNumber, int pageSize)
        {
            return _context.Options.AsNoTracking()
                .Where(o => o.Question.SurveyId == surveyId)
                .Select(x => new
                {
                    x.OptionNumber,
                    x.Text,
                    VotesCount = x.Votes.Count,
                    TotalVotes = x.Question.Options.Sum(o => o.Votes.Count)
                })
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize)
                .Select(x => new GetOptionsWithVotesDetailDto()
                {
                    OptionNumber = x.OptionNumber,
                    OptionText = x.Text,
                    NumberOfVotes = x.VotesCount,
                    PercentageOfVotes = x.TotalVotes == 0 ? 0 : (float)Math.Round((x.VotesCount * 100.0f) / x.TotalVotes, 2)
                }).OrderByDescending(v => v.NumberOfVotes)
                .ThenBy(v => v.OptionNumber)
                .ToList();
        }
    }
}

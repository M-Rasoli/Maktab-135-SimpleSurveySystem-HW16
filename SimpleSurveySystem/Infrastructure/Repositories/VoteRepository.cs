using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.Contracts.RepositoryContracts;
using SimpleSurveySystem.DTOs;
using SimpleSurveySystem.Entities;

namespace SimpleSurveySystem.Infrastructure.Repositories
{
    public class VoteRepository(AppDbContext _context) : IVoteRepository
    {
        public int CreateNewVote(CreateVoteDto vote)
        {
            Vote newVote = new Vote()
            {
                OptionId = vote.OptionId,
                QuestionId = vote.QuestionId,
                SurveyId = vote.SurveyId,
                UserId = vote.UserId
            };
            _context.Votes.Add(newVote);
            _context.SaveChanges();
            return vote.OptionId;
        }
    }
}

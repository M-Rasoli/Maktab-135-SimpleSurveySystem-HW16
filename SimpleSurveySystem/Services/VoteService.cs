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
    public class VoteService(IVoteRepository _voteRepository) : IVoteService
    {
        public int CreateNewVote(CreateVoteDto vote)
        {
            return _voteRepository.CreateNewVote(vote);
        }
    }
}

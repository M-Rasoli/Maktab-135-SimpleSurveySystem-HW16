using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSurveySystem.DTOs;

namespace SimpleSurveySystem.Contracts.RepositoryContracts
{
    public interface IVoteRepository
    {
        int CreateNewVote(CreateVoteDto vote);
    }
}

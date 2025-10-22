using SimpleSurveySystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveySystem.Contracts.ServiceContracts
{
    public interface IVoteService
    {
        int CreateNewVote(CreateVoteDto vote);
    }
}

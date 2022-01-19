using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICandidateService
    {
        Task<Candidate> GetCandidate(int id);
        Task<IList<Candidate>> GetCandidates();
    }
}

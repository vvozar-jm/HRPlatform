using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task<IList<Candidate>> GetCandidatesAsync();
        Task CreateCandidateAsync(Candidate candidate);
    }
}

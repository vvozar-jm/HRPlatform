using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICandidateService
    {
        Task<Candidate> GetCandidateAsync(int id);
        Task<IList<Candidate>> GetCandidatesAsync();
        Task<Candidate> CreateCandidateAsync(Candidate candidate);
        Task DeleteCandidateAsync(Candidate candidate);
    }
}

using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateById(int id);
        Task<IList<Candidate>> GetCandidates();
    }
}

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
        Task DeleteCandidateAsync(Candidate candidate);
        Task<IList<Candidate>> GetCandidatesByNameAsync(string name);
        Task<IList<Candidate>> GetCandidatesBySkillAsync(Skill skill);
        Task<Candidate> AddSkillToCandidateAsync(int candidateId, int skillId);
        Task<Candidate> RemoveSkillFromCandidateAsync(int candidateId, int skillId);
    }
}

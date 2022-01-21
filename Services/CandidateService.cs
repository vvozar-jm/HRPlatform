using Core.Entities;
using Core.Repositories;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISkillRepository _skillRepository;

        public CandidateService(ICandidateRepository candidateRepository, ISkillRepository skillRepository)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public async Task<Candidate> GetCandidateAsync(int id)
        {
            return await _candidateRepository.GetCandidateByIdAsync(id);
        }

        public async Task<IList<Candidate>> GetCandidatesAsync()
        {
            return await _candidateRepository.GetCandidatesAsync();
        }

        public async Task<Candidate> CreateCandidateAsync(Candidate candidate)
        {
            await _candidateRepository.CreateCandidateAsync(candidate);
            return candidate;
        }

        public async Task DeleteCandidateAsync(Candidate candidate)
        {
            await _candidateRepository.DeleteCandidateAsync(candidate);
        }

        public async Task<IList<Candidate>> GetCandidatesByNameAsync(string name)
        {
            return await _candidateRepository.GetCandidatesByNameAsync(name);
        }

        public async Task<IList<Candidate>> GetCandidatesBySkillAsync(string skillName)
        {
            var skill = await _skillRepository.GetSkillByNameAsync(skillName);

            if (skill == null)
            {
                return null;
            }

            return await _candidateRepository.GetCandidatesBySkillAsync(skill);
        }

        public async Task<Candidate> AddSkillToCandidateAsync(int candidateId, int skillId)
        {
            return await _candidateRepository.AddSkillToCandidateAsync(candidateId, skillId);
        }

        public async Task<Candidate> RemoveSkillFromCandidateAsync(int candidateId, int skillId)
        {
            return await _candidateRepository.RemoveSkillFromCandidateAsync(candidateId, skillId);
        }
    }
}

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

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
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
    }
}

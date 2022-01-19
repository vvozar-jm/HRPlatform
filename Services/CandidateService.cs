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

        public async Task<Candidate> GetCandidate(int id)
        {
            return await _candidateRepository.GetCandidateById(id);
        }

        public async Task<IList<Candidate>> GetCandidates()
        {
            return await _candidateRepository.GetCandidates();
        }
    }
}

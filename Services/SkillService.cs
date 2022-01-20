using Core.Entities;
using Core.Repositories;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> GetSkillAsync(int id)
        {
            return await _skillRepository.GetSkillByIdAsync(id);
        }

        public async Task<IList<Skill>> GetSkillsAsync()
        {
            return await _skillRepository.GetSkillsAsync();
        }

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            await _skillRepository.CreateSkillAsync(skill);
            return skill;
        }

        public async Task DeleteSkillAsync(Skill skill)
        {
            await _skillRepository.DeleteSkillAsync(skill);
        }
    }
}

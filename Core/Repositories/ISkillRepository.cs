using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISkillRepository
    {
        Task<Skill> GetSkillByIdAsync(int id);
        Task<IList<Skill>> GetSkillsAsync();
    }
}

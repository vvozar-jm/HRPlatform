using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISkillRepository
    {
        Task<Skill> GetSkillById(int id);
        Task<IList<Skill>> GetSkills();
    }
}

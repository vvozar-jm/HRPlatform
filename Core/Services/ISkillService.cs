using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ISkillService
    {
        Task<Skill> GetSkill(int id);
        Task<IList<Skill>> GetSkills();
    }
}

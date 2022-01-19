using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly HrPlatformDbContext _context;

        public SkillRepository(HrPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IList<Skill>> GetSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }
    }
}

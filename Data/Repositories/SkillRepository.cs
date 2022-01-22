using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateSkillAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _context.Skills
                .Include(s => s.Candidates)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Skill> GetSkillByNameAsync(string skillName)
        {
            return await _context.Skills
                .Where(s => s.Name == skillName)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Skill>> GetSkillsAsync()
        {
            return await _context.Skills
                .Include(s => s.Candidates)
                .ToListAsync();
        }
    }
}

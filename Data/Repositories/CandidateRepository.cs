using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly HrPlatformDbContext _context;

        public CandidateRepository(HrPlatformDbContext context)
        {
            _context = context;
        }

        public async Task CreateCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _context.Candidates
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Candidate>> GetCandidatesAsync()
        {
            return await _context.Candidates
                .Include(c => c.Skills)
                .ToListAsync();
        }

        public async Task<IList<Candidate>> GetCandidatesByNameAsync(string name)
        {
            return await _context.Candidates
                .Where(c => c.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                .Include(c => c.Skills)
                .ToListAsync();
        }

        public async Task<IList<Candidate>> GetCandidatesBySkillAsync(Skill skill)
        {
            return await _context.Candidates
                .Where(c => c.Skills.Contains(skill))
                .Include(c => c.Skills)
                .ToListAsync();
        }
    }
}

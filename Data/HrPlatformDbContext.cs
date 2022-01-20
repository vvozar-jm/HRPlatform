using Core.Entities;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HrPlatformDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public HrPlatformDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CandidateConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
        }
    }
}

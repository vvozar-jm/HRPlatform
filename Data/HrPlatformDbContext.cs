﻿using Core.Entities;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HrPlatformDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }


        public HrPlatformDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CandidateConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
            builder.ApplyConfiguration(new CandidateSkillConfiguration());
        }
    }
}
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CandidateSkillConfiguration : IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<CandidateSkill> builder)
        {
            builder.HasKey(cs => new { cs.CandidateId, cs.SkillId });

            builder.HasOne<Candidate>(cs => cs.Candidate)
                .WithMany(c => c.CandidateSkill)
                .HasForeignKey(cs => cs.CandidateId);

            builder.HasOne<Skill>(cs => cs.Skill)
                .WithMany(c => c.CandidateSkill)
                .HasForeignKey(cs => cs.SkillId);
        }
    }
}

using System.Collections.Generic;

namespace Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill() { }

        public string Name { get; set; }
        public IList<CandidateSkill> CandidateSkill { get; set; }

    }
}

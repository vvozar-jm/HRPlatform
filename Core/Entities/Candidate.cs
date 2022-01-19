using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Candidate : BaseEntity
    {
        public Candidate() { }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public IList<CandidateSkill> CandidateSkill { get; set; }
    }
}

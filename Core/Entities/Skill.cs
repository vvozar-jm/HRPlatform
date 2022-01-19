using System.Collections.Generic;

namespace Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
            Candidates = new List<Candidate>();
        }

        public string Name { get; set; }
        public IList<Candidate> Candidates { get; set; }
    }
}

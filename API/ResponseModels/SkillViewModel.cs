using System.Collections.Generic;

namespace API.ResponseModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BaseCandidateViewModel> Candidates { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API.ResponseModels
{
    public class CandidateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public ICollection<BaseSkillViewModel> Skills { get; set; }
    }
}

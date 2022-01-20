using System;

namespace API.RequestModels
{
    public class CreateCandidateModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}

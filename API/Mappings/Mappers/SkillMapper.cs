using API.Mappings.Contracts;
using API.RequestModels;
using API.ResponseModels;
using Core.Entities;
using System.Collections.Generic;

namespace API.Mappings.Mappers
{
    public class SkillMapper : ISkillMapper
    {
        public Skill MapFromCreateSkillModel(CreateSkillModel model)
        {
            return new Skill
            {
                Name = model.Name
            };
        }

        public SkillViewModel MapToSkillViewModel(Skill model)
        {
            var baseCandidateViewModels = new List<BaseCandidateViewModel>();
            foreach (var candidate in model.Candidates)
            {
                baseCandidateViewModels.Add(new BaseCandidateViewModel
                {
                    Id = candidate.Id,
                    Name = candidate.Name,
                    DateOfBirth = candidate.DateOfBirth,
                    ContactNumber = candidate.ContactNumber,
                    Email = candidate.Email
                });
            }

            var skillViewModel = new SkillViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Candidates = baseCandidateViewModels
            };

            return skillViewModel;
        }
    }
}

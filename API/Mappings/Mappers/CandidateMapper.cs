using API.Mappings.Contracts;
using API.RequestModels;
using API.ResponseModels;
using Core.Entities;
using System.Collections.Generic;

namespace API.Mappings.Mappers
{
    public class CandidateMapper : ICandidateMapper
    {
        private readonly ISkillMapper _skillMapper;

        public CandidateMapper(ISkillMapper skillMapper)
        {
            _skillMapper = skillMapper;
        }

        public Candidate MapFromCreateCandidateModel(CreateCandidateModel model)
        {
            return new Candidate
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                ContactNumber = model.ContactNumber,
                Email = model.Email
            };
        }

        public CandidateViewModel MapToCandidateViewModel(Candidate model)
        {
            var baseSkillViewModels = new List<BaseSkillViewModel>();
            foreach (var skill in model.Skills)
            {
                baseSkillViewModels.Add(new BaseSkillViewModel
                {
                    Id = skill.Id,
                    Name = skill.Name
                });
            }

            var candidateViewModel = new CandidateViewModel
            {
                Id = model.Id,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                Skills = baseSkillViewModels
            };

            return candidateViewModel;
        }
    }
}

using API.ViewModels;
using AutoMapper;
using Core.Entities;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // domain to viewModel
            CreateMap<Candidate, CandidateViewModel>();
            CreateMap<Skill, SkillViewModel>();

            // viewModel to domain
            CreateMap<CandidateViewModel, Candidate>();
            CreateMap<SkillViewModel, Skill>();
        }
    }
}

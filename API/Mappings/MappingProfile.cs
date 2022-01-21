using API.RequestModels;
using AutoMapper;
using Core.Entities;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCandidateModel, Candidate>();
            CreateMap<CreateSkillModel, Skill>();
        }
    }
}

using API.RequestModels;
using API.ResponseModels;
using Core.Entities;

namespace API.Mappings.Contracts
{
    public interface ISkillMapper
    {
        Skill MapFromCreateSkillModel(CreateSkillModel model);
        SkillViewModel MapToSkillViewModel(Skill model);
    }
}

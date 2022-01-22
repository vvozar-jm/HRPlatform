using API.RequestModels;
using Core.Entities;

namespace API.Mappings.Contracts
{
    public interface ISkillMapper
    {
        Skill MapFromCreateSkillModel(CreateSkillModel model);
    }
}

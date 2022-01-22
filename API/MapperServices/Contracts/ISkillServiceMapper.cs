using API.RequestModels;
using Core.Entities;

namespace API.MapperServices.Contracts
{
    public interface ISkillServiceMapper
    {
        Skill MapFromCreateSkillModel(CreateSkillModel model);
    }
}

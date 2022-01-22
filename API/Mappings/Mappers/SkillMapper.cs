using API.Mappings.Contracts;
using API.RequestModels;
using Core.Entities;

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
    }
}

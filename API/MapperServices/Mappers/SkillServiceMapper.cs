using API.MapperServices.Contracts;
using API.RequestModels;
using Core.Entities;

namespace API.MapperServices.Mappers
{
    public class SkillServiceMapper : ISkillServiceMapper
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

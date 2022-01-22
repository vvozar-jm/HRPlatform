using API.MapperServices.Contracts;
using API.RequestModels;
using API.Validators;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly ISkillServiceMapper _mapper;

        public SkillsController(ISkillService skillService, ISkillServiceMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<Skill>>> GetAllSkillsAsync()
        {
            var skills = await _skillService.GetSkillsAsync();

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillByIdAsync(int id)
        {
            var skill = await _skillService.GetSkillAsync(id);

            if (skill == null)
            {
                return BadRequest("Skill with given Id not found!");
            }

            return Ok(skill);
        }

        [HttpPost("")]
        public async Task<ActionResult<Skill>> CreateSkillAsync([FromBody] CreateSkillModel model)
        {
            var validator = new CreateSkillModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var skillToCreate = _mapper.MapFromCreateSkillModel(model);

            var newSkill = await _skillService.CreateSkillAsync(skillToCreate);

            return Ok(newSkill);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkillAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var skill = await _skillService.GetSkillAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            await _skillService.DeleteSkillAsync(skill);

            return NoContent();
        }
    }
}

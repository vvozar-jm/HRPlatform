using API.Mappings.Contracts;
using API.RequestModels;
using API.ResponseModels;
using API.Validators;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly ISkillMapper _mapper;

        public SkillsController(ISkillService skillService, ISkillMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<SkillViewModel>>> GetAllSkillsAsync()
        {
            var skills = await _skillService.GetSkillsAsync();
            var skillViewModels = (skills.Select(skill => _mapper.MapToSkillViewModel(skill))).ToList();

            return Ok(skillViewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillViewModel>> GetSkillByIdAsync(int id)
        {
            var skill = await _skillService.GetSkillAsync(id);

            if (skill == null)
            {
                return BadRequest("Skill with given Id not found!");
            }

            return Ok(_mapper.MapToSkillViewModel(skill));
        }

        [HttpPost("")]
        public async Task<ActionResult<SkillViewModel>> CreateSkillAsync([FromBody] CreateSkillModel model)
        {
            var validator = new CreateSkillModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var skillToCreate = _mapper.MapFromCreateSkillModel(model);

            var newSkill = await _skillService.CreateSkillAsync(skillToCreate);

            return Ok(_mapper.MapToSkillViewModel(newSkill));
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

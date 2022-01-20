using API.RequestModels;
using API.Validators;
using API.ViewModels;
using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<SkillViewModel>>> GetAllSkillsAsync()
        {
            var skills = await _skillService.GetSkillsAsync();
            var result = _mapper.Map<IList<SkillViewModel>>(skills);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillViewModel>> GetSkillByIdAsync(int id)
        {
            var skill = await _skillService.GetSkillAsync(id);
            var result = _mapper.Map<SkillViewModel>(skill);

            return Ok(result);
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

            var skillToCreate = _mapper.Map<CreateSkillModel, Skill>(model);

            var newSkill = await _skillService.CreateSkillAsync(skillToCreate);

            var skillViewModel = _mapper.Map<Skill, CandidateViewModel>(newSkill);

            return Ok(skillViewModel);
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

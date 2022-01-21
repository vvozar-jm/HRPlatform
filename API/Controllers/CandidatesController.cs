using API.RequestModels;
using API.Validators;
using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateService candidateService, ISkillService skillService, IMapper mapper)
        {
            _candidateService = candidateService;
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<Candidate>>> GetAllCandidatesAsync()
        {
            var candidates = await _candidateService.GetCandidatesAsync();
            
            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateService.GetCandidateAsync(id);

            if (candidate == null)
            {
                return BadRequest("Candidate with given Id not found!");
            }

            return Ok(candidate);
        }

        [HttpGet("searchbyname/{name}")]
        public async Task<ActionResult<IList<Candidate>>> SearchCandidatesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is empty.");
            }

            var candidates = await _candidateService.GetCandidatesByNameAsync(name);

            return Ok(candidates);
        }

        [HttpGet("searchbyskill/{skillName}")]
        public async Task<ActionResult<IList<Candidate>>> SearchCandidatesBySkillNameAsync(string skillName)
        {
            if (string.IsNullOrWhiteSpace(skillName))
            {
                return BadRequest("Skill name is empty.");
            }

            var candidates = await _candidateService.GetCandidatesBySkillAsync(skillName);

            return Ok(candidates);
        }

        [HttpPost("")]
        public async Task<ActionResult<Candidate>> CreateCandidateAsync([FromBody] CreateCandidateModel model)
        {
            var validator = new CreateCandidateModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var candidateToCreate = _mapper.Map<CreateCandidateModel, Candidate>(model);

            var newCandidate = await _candidateService.CreateCandidateAsync(candidateToCreate);

            return Ok(newCandidate);
        }

        [HttpPut("{candidateId}/addskill/{skillId}")]
        public async Task<ActionResult<Candidate>> AddSkillToCandidateAsync(int candidateId, int skillId)
        {
            var candidate = await _candidateService.GetCandidateAsync(candidateId);

            if (candidate == null)
            {
                return BadRequest("Invalid candidate Id");
            }

            var skill = await _skillService.GetSkillAsync(skillId);

            if (skill == null)
            {
                return BadRequest("Invalid skill Id");
            }

            if (candidate.Skills.Contains(skill))
            {
                return BadRequest("Candidate already contains given skill");
            }

            var updatedCandidate = await _candidateService.AddSkillToCandidateAsync(candidateId, skillId);

            return Ok(updatedCandidate);
        }

        [HttpPut("{candidateId}/removeskill/{skillId}")]
        public async Task<ActionResult<Candidate>> RemoveSkillFromCandidateAsync(int candidateId, int skillId)
        {
            var candidate = await _candidateService.GetCandidateAsync(candidateId);

            if (candidate == null)
            {
                return BadRequest("Invalid candidate Id");
            }

            var skill = await _skillService.GetSkillAsync(skillId);

            if (skill == null)
            {
                return BadRequest("Invalid skill Id");
            }

            if (!candidate.Skills.Contains(skill))
            {
                return BadRequest("Candidate does not contain given skill");
            }

            var updatedCandidate = await _candidateService.RemoveSkillFromCandidateAsync(candidateId, skillId);

            return Ok(updatedCandidate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCandidateAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var candidate = await _candidateService.GetCandidateAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateService.DeleteCandidateAsync(candidate);

            return NoContent();
        }
    }
}

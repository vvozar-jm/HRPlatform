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
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<CandidateViewModel>>> GetAllCandidatesAsync()
        {
            var candidates = await _candidateService.GetCandidatesAsync();
            var result = _mapper.Map<IList<CandidateViewModel>>(candidates);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateViewModel>> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateService.GetCandidateAsync(id);
            var result = _mapper.Map<CandidateViewModel>(candidate);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult<CandidateViewModel>> CreateCandidateAsync([FromBody] CreateCandidateModel model)
        {
            var validator = new CreateCandidateModelValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var candidateToCreate = _mapper.Map<CreateCandidateModel, Candidate>(model);

            var newCandidate = await _candidateService.CreateCandidateAsync(candidateToCreate);

            var candidateViewModel = _mapper.Map<Candidate, CandidateViewModel>(newCandidate);

            return Ok(candidateViewModel);
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

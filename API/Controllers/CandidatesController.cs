using API.ViewModels;
using AutoMapper;
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
    }
}

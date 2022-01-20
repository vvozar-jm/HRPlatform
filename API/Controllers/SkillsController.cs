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
    }
}

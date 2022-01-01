using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerly.Models;
using Careerly.Repositories;

namespace Careerly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Experience>> GetExperiences()
        {
            return await _experienceRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id) 
        {
            return await _experienceRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> PostExperience([FromBody] Experience experience)
        {
            var newExperience = await _experienceRepository.Create(experience);
            return CreatedAtAction(nameof(GetExperience), new { id = experience.ID }, newExperience);
        }

        [HttpPut]
        public async Task<ActionResult<Experience>> PutExperience(int id, [FromBody] Experience experience)
        {
           if(experience.ID != id)
            {
                return BadRequest();
            }
            await _experienceRepository.Update(experience);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Experience>> PutExperience(int id)
        {
            var ExperienceToDelete = await _experienceRepository.Get(id);
            if(ExperienceToDelete == null)
            {
                return NotFound();
            }
            await _experienceRepository.Delete(id);
            return NoContent();
        }

    }
}

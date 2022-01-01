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
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Education>> GetEducations()
        {
            return await _educationRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
            return await _educationRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Education>> PostEducation([FromBody] Education education)
        {
            var newEducation = await _educationRepository.Create(education);
            return CreatedAtAction(nameof(GetEducation), new { id = education.ID }, newEducation);
        }

        [HttpPut]
        public async Task<ActionResult<Education>> PutEducation(int id, [FromBody] Education education)
        {
            if (education.ID != id)
            {
                return BadRequest();
            }
            await _educationRepository.Update(education);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Education>> DeleteEducation(int id)
        {
            var educationToDelete = await _educationRepository.Get(id);
            if (educationToDelete == null)
            {
                return NotFound();
            }
            await _educationRepository.Delete(id);
            return NoContent();
        }

    }
}

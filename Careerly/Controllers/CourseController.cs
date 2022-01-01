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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            return await _courseRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse([FromBody] Course course)
        {
            var newCourse = await _courseRepository.Create(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.ID }, newCourse);
        }

        [HttpPut]
        public async Task<ActionResult<Course>> PutCourse(int id, [FromBody] Course course)
        {
            if (course.ID != id)
            {
                return BadRequest();
            }
            await _courseRepository.Update(course);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Course>> PutCourse(int id)
        {
            var CourseToDelete = await _courseRepository.Get(id);
            if (CourseToDelete == null)
            {
                return NotFound();
            }
            await _courseRepository.Delete(id);
            return NoContent();
        }

    }
}

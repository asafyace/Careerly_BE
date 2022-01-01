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
    public class AwardController : ControllerBase
    {
        private readonly IAwardRepository _awardRepository;

        public AwardController(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Award>> GetAwards()
        {
            return await _awardRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetAward(int id)
        {
            return await _awardRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Award>> PostAward([FromBody] Award award)
        {
            var newaward = await _awardRepository.Create(award);
            return CreatedAtAction(nameof(GetAward), new { id = award.ID }, newaward);
        }

        [HttpPut]
        public async Task<ActionResult<Award>> PutAward(int id, [FromBody] Award award)
        {
            if (award.ID != id)
            {
                return BadRequest();
            }
            await _awardRepository.Update(award);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Award>> DeleteAward(int id)
        {
            var AwardToDelete = await _awardRepository.Get(id);
            if (AwardToDelete == null)
            {
                return NotFound();
            }
            await _awardRepository.Delete(id);
            return NoContent();
        }

    }
}

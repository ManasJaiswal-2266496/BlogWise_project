using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteMicroservice.BusinessLayer.ModelDto;
using VoteMicroservice.BusinessLayer.Services;

namespace VoteMicroservice.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoteDto>>> GetAllVotesAsync()
        {
            var votes = await _voteService.GetAllVotesAsync();
            return Ok(votes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoteDto>> GetVoteByIdAsync(int id)
        {
            var vote = await _voteService.GetVoteByIdAsync(id);
            if (vote == null)
                return NotFound();

            return Ok(vote);
        }

        [HttpPost]
        public async Task<ActionResult<VoteDto>> CreateVoteAsync(VoteDto vote)
        {
            var createdVote = await _voteService.CreateVoteAsync(vote);
            return CreatedAtAction(nameof(GetVoteByIdAsync), new { id = createdVote.VoteId }, createdVote);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVoteAsync(int id, VoteDto vote)
        {
            if (id != vote.VoteId)
                return BadRequest();

            var result = await _voteService.UpdateVoteAsync(vote);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVoteAsync(int id)
        {
            var result = await _voteService.DeleteVoteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

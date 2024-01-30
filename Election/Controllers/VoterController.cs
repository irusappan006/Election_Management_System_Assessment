using Election.Class;
using Election.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public VoterController(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetVoters(int PageNo, int PageSize, String voterIdNumber, String name, bool isApproved)
        {
            try
            {
                var result = await _dbContext.Voters.Where(x => x.VoterIdNumber.Contains(voterIdNumber)
                && x.Name.Contains(name) && x.IsApproved == isApproved).ToListAsync();

                return Ok(result.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVoter(Voter voter)
        {
            try
            {
                await _dbContext.Voters.AddAsync(voter);
                await _dbContext.SaveChangesAsync();
                return Ok(await _dbContext.Voters.FindAsync(voter.VoterId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoter(int id)
        {
            try
            {
                var result = await _dbContext.Voters.FirstOrDefaultAsync(x => x.VoterId == id);
                if (result == null)
                {
                    return NotFound("Check VoterId");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetVoterByNumber")]
        public async Task<IActionResult> GetVoterByNumber(String? VoterIdNumber)
        {
            try
            {
                var result = await _dbContext.Voters.FirstOrDefaultAsync(x => x.VoterIdNumber.Contains(VoterIdNumber));
                if (result == null)
                {
                    return NotFound("Check VoterId");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVoter(Voter voter)
        {
            try
            {
                var result = await _dbContext.Voters.FirstOrDefaultAsync(x => x.VoterId == voter.VoterId);

                if (result == null)
                {
                    return NotFound("Check CandidateId");
                }

                //_dbContext.Update(task);
                await _dbContext.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoter(int id)
        {
            try
            {
                var result = await _dbContext.Voters.FirstOrDefaultAsync(x => x.VoterId == id);
                if (result == null)
                {
                    return NotFound();
                }
                _dbContext.Voters.Remove(result);

                return Ok(await _dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("CreateVote")]
        public async Task<IActionResult> CreateVote(Vote vote)
        {
            try
            {
                await _dbContext.Votes.AddAsync(vote);
                await _dbContext.SaveChangesAsync();
                return Ok("Voted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("VotedCountByCandidate")]
        public async Task<IActionResult> GetVotedList(int candidateId)
        {
            try
            {
                var result = await _dbContext.Voters.Where(x => x.CandidateId == candidateId).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}

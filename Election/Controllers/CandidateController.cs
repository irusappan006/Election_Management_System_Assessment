using Election.Class;
using Election.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CandidateController(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                return Ok(await _dbContext.Candidates.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandiate(Candidate candidate)
        {
            try
            {
                await _dbContext.Candidates.AddAsync(candidate);
                await _dbContext.SaveChangesAsync();
                return Ok(await _dbContext.Candidates.FindAsync(candidate.CandidateId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            try
            {
                var result = await _dbContext.Candidates.Include(c => c.State).Include(c => c.Party).FirstOrDefaultAsync(x => x.CandidateId == id);
                if (result == null)
                {
                    return NotFound("Check CandidateId");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCandidate(Candidate candidate)
        {
            try
            {
                var result = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.CandidateId == candidate.CandidateId);

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
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                var result = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.CandidateId == id);
                if (result == null)
                {
                    return NotFound();
                }
                _dbContext.Candidates.Remove(result);

                return Ok(await _dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

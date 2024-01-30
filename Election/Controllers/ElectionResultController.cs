using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Election.DBContext;
using Election.Class;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionResultController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public ElectionResultController(AppDbContext appContext) { 
            _dbContext = appContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetElectionResults(int PageNo, int PageSize)
        {
            try
            {
                var result = await _dbContext.Voters.ToListAsync();

                return Ok(result.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateElectionResult(ElectionResult electionResult)
        {
            try
            {
                await _dbContext.ElectionResults.AddAsync(electionResult);
                await _dbContext.SaveChangesAsync();
                return Ok(await _dbContext.ElectionResults.FindAsync(electionResult.ElectionResultId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElectionResult(int id)
        {
            try
            {
                var task = await _dbContext.ElectionResults.FirstOrDefaultAsync(x => x.ElectionResultId == id);
                if (task == null)
                {
                    return NotFound("Check ElectionId");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ElectionResultByCandidate/{id}")]
        public async Task<IActionResult> GetElectionResultByCandidate(int id)
        {
            try
            {
                var task = await _dbContext.ElectionResults.FirstOrDefaultAsync(x => x.CandidateId == id);
                if (task == null)
                {
                    return NotFound("Check CandidateId");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateElectionResult(ElectionResult electionResult)
        {
            try
            {
                var result = await _dbContext.ElectionResults.FirstOrDefaultAsync(x => 
                x.ElectionResultId == electionResult.ElectionResultId && 
                x.CandidateId == electionResult.CandidateId );

                if (result == null)
                {
                    return NotFound("Check Both Election and Candidate Id");
                }
                result.NumberOfVotes = electionResult.NumberOfVotes;

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
        public async Task<IActionResult> DeleteElectionResult(int id)
        {
            try
            {
                var result = await _dbContext.ElectionResults.FirstOrDefaultAsync(x => x.ElectionResultId == id);
                if (result == null)
                {
                    return NotFound("Check ElectionId");
                }
                _dbContext.ElectionResults.Remove(result);

                return Ok(await _dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

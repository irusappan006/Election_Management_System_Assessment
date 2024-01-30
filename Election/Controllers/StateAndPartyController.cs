using Election.Class;
using Election.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateAndPartyController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public StateAndPartyController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        [HttpGet("GetParties")]
        public async Task<IActionResult> GetParties(int PageNo, int PageSize, string name)
        {
            try
            {
                var result = await _dbContext.Parties.Where(x => x.Name.Contains(name)).ToListAsync();

                return Ok(result.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPartyCandidates")]
        public async Task<ActionResult> GetPartyCandidates(int partyId, int PageNo, int PageSize)
        {
            try
            {
                var result = await _dbContext.Parties.Include(x => x.Candidates).Where(x => x.PartyId == partyId).ToListAsync();

                return Ok(result.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateParty")]
        public async Task<IActionResult> CreateParty(Party party)
        {
            try
            {
                await _dbContext.Parties.AddAsync(party);
                await _dbContext.SaveChangesAsync();
                return Ok(await _dbContext.ElectionResults.FindAsync(party.PartyId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetStatea(int PageNo, int PageSize, string name)
        {
            try
            {
                var result = await _dbContext.States.Where(x => x.Name.Contains(name)).ToListAsync();

                return Ok(result.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetStateCandidates")]
        public async Task<ActionResult> GetStateCandidates(int stateId, int PageNo, int PageSize)
        {
            try
            {
                var result = await _dbContext.States.Include(x => x.Candidates).Where(x => x.StateId == stateId).ToListAsync();

                return Ok(result.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateState")]
        public async Task<IActionResult> CreateState(State state)
        {
            try
            {
                await _dbContext.States.AddAsync(state);
                await _dbContext.SaveChangesAsync();
                return Ok(await _dbContext.States.FindAsync(state.StateId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

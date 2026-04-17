using MFS.SportsApp.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

using MFS.SportsApp.Models;

namespace MFS.SportsApp.Service.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamRosterController : ControllerBase
    {
        private readonly ITeamRosterRepository _repository;

        public TeamRosterController(ITeamRosterRepository repository)
        {
            _repository = repository;
        }

        // GET: api/teamroster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamRoster>>> GetAll()
        {
            var rosters = await _repository.GetAllAsync();
            return Ok(rosters);
        }

        // GET: api/teamroster/team/5/year/2023
        [HttpGet("team/{teamId}/year/{year}")]
        public async Task<ActionResult<IEnumerable<TeamRoster>>> GetByTeam(int teamId, string year)
        {
            var roster = await _repository.GetRosterByTeamAsync(teamId, year);

            if (roster == null || !roster.Any())
            {
                return NotFound($"No roster found for Team ID {teamId} in year {year}.");
            }

            return Ok(roster);
        }
    }
}

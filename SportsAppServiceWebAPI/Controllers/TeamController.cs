using MFS.SportsApp.DataAccess;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MFS.SportsApp.Service.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : Controller<Team>
{
    public TeamsController(ITeamRepository repo) : base(repo) { }

    private ITeamRepository Repo => _repo as ITeamRepository;

    //// GET: api/leagues/5/teams
    //[HttpGet("{id}/teams")]
    //public async Task<ActionResult<IEnumerable<Team>>> GetLeagueTeams(int id)
    //{
    //    var league = await _context.Leagues
    //        .Include(l => l.Teams)
    //        .FirstOrDefaultAsync(l => l.LeagueId == id);

    //    if (league == null)
    //    {
    //        return NotFound(new { message = $"League with ID {id} not found." });
    //    }

    //    return league.Teams.Where(t => t.IsActive).ToList(); // Assuming Team has IsActive
    //}
}

using MFS.SportsApp.DataAccess;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MFS.SportsApp.Service.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaguesController : Controller<League>
{
    public LeaguesController(ILeagueRepository repo) : base(repo) { }

    private ILeagueRepository Repo => _repo as ILeagueRepository;

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] League league)
    {
        if (league == null || league.LeagueId != id) return BadRequest();
        var existing = await Repo.GetByIdAsync(id);
        if (existing == null) return NotFound();

        // copy fields
        existing.LeagueId = league.LeagueId;
        existing.LeagueName = league.LeagueName;
        existing.Country = league.Country;
        existing.SportId = league.SportId;
        existing.Level = league.Level;

        await Repo.UpdateAsync(existing, id);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] League league)
    {
        if (league == null) return BadRequest();
        var created = await Repo.CreateAsync(league);
        return CreatedAtAction(nameof(Get), new { id = created.LeagueId }, created);
    }
}

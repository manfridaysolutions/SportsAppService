using MFS.SportsApp.DataAccess;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using MFS.SportsApp.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MFS.SportsApp.Service.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthletesController : Controller<Athlete>
{
    public AthletesController(IAthleteRepository repo) : base(repo) { }

    private IAthleteRepository Repo => _repo as IAthleteRepository;

    // GET api/athletes/team/5
    [HttpGet("team/{teamId}")]
    public async Task<IActionResult> GetByTeamId(int teamId)
    {
        if (teamId <= 0) return BadRequest("teamId must be a positive integer.");

        var athletes = await Repo.GetByTeamIdAsync(teamId);

        // return 200 with empty array if none found; optionally return 404 instead:
        return Ok(athletes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Athlete athlete)
    {
        if (athlete == null) return BadRequest();
        var created = await Repo.CreateAsync(athlete);

        return RecursionHelper.GetKeyPropertyInfo<Athlete>(created) is (string keyName, object keyValue) 
            ? CreatedAtAction(nameof(Get), new { id = keyValue }, created) 
            : NoContent();

        // return CreatedAtAction(nameof(Get), new { id = created.AthleteId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Athlete athlete)
    {
        if (athlete == null || athlete.AthleteId != id) return BadRequest();
        var existing = await Repo.GetByIdAsync(id);
        if (existing == null) return NotFound();

        // copy fields
        existing.FirstName = athlete.FirstName;
        existing.LastName = athlete.LastName;
        existing.DisplayName = athlete.DisplayName;
        existing.BirthDate = athlete.BirthDate;
        existing.Nationality = athlete.Nationality;
        existing.HeightInches = athlete.HeightInches;
        existing.WeightLbs = athlete.WeightLbs;
        existing.IsActive = athlete.IsActive;
        existing.Rosters = athlete.Rosters;
        existing.AthleteId = athlete.AthleteId;

        await Repo.UpdateAsync(existing, id);
        return NoContent();
    }
}

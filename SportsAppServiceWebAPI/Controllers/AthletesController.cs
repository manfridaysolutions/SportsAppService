using Microsoft.AspNetCore.Mvc;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;

namespace MFS.SportsApp.Service.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthletesController : ControllerBase
{
    private readonly IAthleteRepository _repo;

    public AthletesController(IAthleteRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _repo.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    // GET api/athletes/team/5
    [HttpGet("team/{teamId}")]
    public async Task<IActionResult> GetByTeamId(int teamId)
    {
        if (teamId <= 0) return BadRequest("teamId must be a positive integer.");

        var athletes = await _repo.GetByTeamIdAsync(teamId);

        // return 200 with empty array if none found; optionally return 404 instead:
        return Ok(athletes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Athlete athlete)
    {
        if (athlete == null) return BadRequest();
        var created = await _repo.CreateAsync(athlete);
        return CreatedAtAction(nameof(Get), new { id = created.AthleteId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Athlete athlete)
    {
        if (athlete == null || athlete.AthleteId != id) return BadRequest();
        var existing = await _repo.GetByIdAsync(id);
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

        await _repo.UpdateAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}

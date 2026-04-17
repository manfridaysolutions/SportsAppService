using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using MFS.SportsApp.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MFS.SportsApp.Service.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Controller<T> : ControllerBase where T : class
{
    protected readonly IRepository<T> _repo;

    public Controller(IRepository<T> repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] T t1)
    {
        if (t1 == null) return BadRequest();
        var created = await _repo.CreateAsync(t1);

        return RecursionHelper.GetKeyPropertyInfo<T>(created) is (string keyName, object keyValue)
            ? CreatedAtAction(nameof(Get), new { id = keyValue }, created)
            : NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] T t1)
    {
        if (t1 == null) return BadRequest();

        await _repo.UpdateAsync(t1, id);
        return NoContent();
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

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound();
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}

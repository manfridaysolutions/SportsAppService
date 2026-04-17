using Microsoft.AspNetCore.Mvc;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using System.Threading.Tasks;

namespace MFS.SportsApp.Service.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportCategoriesController : ControllerBase
    {
        private readonly ISportCategoryRepository _repo;

        public SportCategoriesController(ISportCategoryRepository repo)
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SportCategory category)
        {
            if (category == null) return BadRequest();
            var created = await _repo.CreateAsync(category);
            return CreatedAtAction(nameof(Get), new { id = created.CategoryId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] SportCategory category)
        {
            if (category == null || category.CategoryId != id) return BadRequest();
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.CategoryName = category.CategoryName;
            existing.Description = category.Description;

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
}

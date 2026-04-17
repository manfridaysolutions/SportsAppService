using Microsoft.AspNetCore.Mvc;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using System.Threading.Tasks;

namespace MFS.SportsApp.Service.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportCategoriesController : Controller<SportCategory>
    {
        public SportCategoriesController(ISportCategoryRepository repo) : base(repo) { }

        private ISportCategoryRepository Repo => _repo as ISportCategoryRepository;

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

            await _repo.UpdateAsync(existing, id);
            return NoContent();
        }
    }
}

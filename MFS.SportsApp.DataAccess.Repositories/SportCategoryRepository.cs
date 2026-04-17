using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class SportCategoryRepository : ISportCategoryRepository
    {
        private readonly SportsDbContext _context;

        public SportCategoryRepository(SportsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SportCategory>> GetAllAsync()
        {
            return await _context.Set<SportCategory>().ToListAsync();
        }

        public async Task<SportCategory?> GetByIdAsync(int id)
        {
            return await _context.Set<SportCategory>().FindAsync(id);
        }

        public async Task<SportCategory> CreateAsync(SportCategory category)
        {
            _context.Set<SportCategory>().Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(SportCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Set<SportCategory>().FindAsync(id);
            if (category != null)
            {
                _context.Set<SportCategory>().Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}

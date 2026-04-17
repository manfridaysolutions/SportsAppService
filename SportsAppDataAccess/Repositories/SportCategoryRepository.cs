using Microsoft.EntityFrameworkCore;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFS.SportsApp.Models;

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


        public Task<SportCategory?> GetByIdAsync(int id)
        {
            return _context.Set<SportCategory>().FindAsync(id).AsTask();
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
            var entity = await _context.Set<SportCategory>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<SportCategory>().Remove(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}

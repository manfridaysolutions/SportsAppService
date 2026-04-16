using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly SportsDbContext _context;

        public AthleteRepository(SportsDbContext context)
        {
            _context = context;
        }

        // 1. Get all athletes
        public async Task<IEnumerable<Athlete>> GetAllAsync()
        {
            return await _context.Athletes.ToListAsync();
        }

        // 2. Get by ID
        public async Task<Athlete?> GetByIdAsync(int id)
        {
            return await _context.Athletes.FindAsync(id);
        }

        // 3. CUSTOM: Get athletes by Team ID
        // This utilizes the navigation property ICollection<Roster> we added to the Athlete class
        public async Task<IEnumerable<Athlete>> GetByTeamIdAsync(int teamId)
        {
            return await _context.Athletes
                .Where(a => a.Rosters.Any(r => r.TeamId == teamId))
                .ToListAsync();
        }

        // 4. Create
        public async Task<Athlete> CreateAsync(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();
            return athlete;
        }

        // 5. Update
        public async Task UpdateAsync(Athlete athlete)
        {
            _context.Entry(athlete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // 6. Delete
        public async Task DeleteAsync(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);
            if (athlete != null)
            {
                _context.Athletes.Remove(athlete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class AthleteRepository : Repository<Athlete>, IAthleteRepository
    {
        public AthleteRepository(SportsDbContext context) : base(context) { }

        // 3. CUSTOM: Get athletes by Team ID
        // This utilizes the navigation property ICollection<Roster> we added to the Athlete class
        public async Task<IEnumerable<Athlete>> GetByTeamIdAsync(int teamId)
        {
            return await _context.Athletes
                .Where(a => a.Rosters.Any(r => r.TeamId == teamId))
                .ToListAsync();
        }
    }
}

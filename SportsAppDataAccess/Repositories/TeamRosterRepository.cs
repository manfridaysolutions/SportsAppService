using System;
using System.Collections.Generic;
using System.Text;

using MFS.SportsApp.Models;
using MFS.SportsApp.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class TeamRosterRepository : ITeamRosterRepository
    {
        private readonly SportsDbContext _context;

        public TeamRosterRepository(SportsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamRoster>> GetRosterByTeamAsync(int teamId, string year)
        {
            return await _context.TeamRosters
                .Where(r => r.TeamId == teamId && r.SeasonYear == year)
                .OrderBy(r => r.PlayerName)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeamRoster>> GetAllAsync()
        {
            return await _context.TeamRosters
                .OrderBy(r => r.TeamName)
                .ThenBy(r => r.PlayerName)
                .ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using MFS.SportsApp.Models;

namespace MFS.SportsApp.DataAccess.Interfaces
{
    public interface ITeamRosterRepository
    {
        Task<IEnumerable<TeamRoster>> GetAllAsync();
        Task<IEnumerable<TeamRoster>> GetRosterByTeamAsync(int teamId, string year);
    }
}

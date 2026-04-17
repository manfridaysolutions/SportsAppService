using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class LeagueRepository : Repository<League>, ILeagueRepository
    {
        public LeagueRepository(SportsDbContext context) : base(context) { }
    }
}

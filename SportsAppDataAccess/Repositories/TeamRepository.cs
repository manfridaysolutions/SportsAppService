using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(SportsDbContext context) : base(context) { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using MFS.SportsApp.Models;

namespace MFS.SportsApp.DataAccess.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        // Add category-specific methods here if needed
    }
}

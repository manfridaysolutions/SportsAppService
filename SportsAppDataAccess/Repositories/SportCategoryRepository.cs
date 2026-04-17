using Microsoft.EntityFrameworkCore;
using MFS.SportsApp.DataAccess.Interfaces;
using MFS.SportsApp.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFS.SportsApp.Models;

namespace MFS.SportsApp.DataAccess.Repositories
{
    public class SportCategoryRepository : Repository<SportCategory>, ISportCategoryRepository
    {
        public SportCategoryRepository(SportsDbContext context) : base(context) { }
    }
}

using MFS.SportsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFS.SportsApp.DataAccess.Interfaces
{
    public interface ISportCategoryRepository : IRepository<SportCategory>
    {
        // Add category-specific methods here if needed
    }
}

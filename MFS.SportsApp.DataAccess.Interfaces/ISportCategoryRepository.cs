using MFS.SportsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFS.SportsApp.DataAccess.Interfaces
{
    public interface ISportCategoryRepository
    {
        Task<IEnumerable<SportCategory>> GetAllAsync();
        Task<SportCategory?> GetByIdAsync(int id);
        Task<SportCategory> CreateAsync(SportCategory category);
        Task UpdateAsync(SportCategory category);
        Task DeleteAsync(int id);
    }
}

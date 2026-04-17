using MFS.SportsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFS.SportsApp.DataAccess.Interfaces
{
    public interface IAthleteRepository : IRepository<Athlete>
    {
        Task<IEnumerable<Athlete>> GetByTeamIdAsync(int teamId);
    }
}

using TBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBackend.Repository
{
    public interface ITeamRepository: IRepository<Team>
    {
         List<Team> FindAllTeams(int id);
    }
}
using TBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TBackend.Repository
{
    public interface ITournamentRepository: IRepository<Tournament>
    {
        List<Tournament> FindHost(int id);
    }
}
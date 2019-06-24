using TBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBackend.Repository.dto;

namespace TBackend.Repository
{
    public interface ITournamentRepository: IRepository<Tournament>
    {
        List<Tournament> FindHost(int id);
        IEnumerable<TournamentDto> GetAllTournaments();
        bool CanGenerate(int id);
        TournamentDto getOneTournament(int id);
        List<Tournament> FindName(string name,int id);
    }
}
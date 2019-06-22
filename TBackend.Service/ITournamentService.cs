using TBackend.Entity;
using System.Collections.Generic;

namespace TBackend.Service
{

    public interface ITournamentService : IService<Tournament>
    {
    Team TrueResults(List<Team> equipos);
    void Fase(List<Team> teams, Tournament Tournament, int fase);
    bool CanGenerate(int tournamentId);
    }
}
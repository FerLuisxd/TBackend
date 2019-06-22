using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface ITournamentService : IService<Tournament>
    {
    Team TrueResults(List<Team> equipos);
    void Fase(List<Team> teams, Tournament Tournament, int fase);
    bool CanGenerate(int tournamentId);
    IEnumerable<TournamentDto> GetAllTournaments();
    }
}
using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface ITournamentService : IService<Tournament>
    {
    bool Handler(int tournamentId);
    bool CanGenerate(int tournamentId);
    IEnumerable<TournamentDto> GetAllTournaments();
    TournamentDto GetOneTournament(int id);

    string generateMatches(int tournamentId, int fase);

    }  
}
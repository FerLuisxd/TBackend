using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface IModeService : IService<Mode>
    {
        string GenerateMatchesMode1(List<Team> equipos, int fase,int TournamentId);

        string GenerateMatchesMode2(List<Team> equipos, int fase,int TournamentId);

        Team TrueResults(List<Team> equipos);
    }
}
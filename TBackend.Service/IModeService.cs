using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface IModeService : IService<Mode>
    {
        int GenerateMatchesMode1(List<Team> equipos, int fase,int TournamentId);

        int GenerateMatchesMode2(List<Team> equipos, int fase);

        Team TrueResults(List<Team> equipos);
    }
}
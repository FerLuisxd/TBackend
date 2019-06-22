using TBackend.Entity;
using System.Collections.Generic;

namespace TBackend.Service
{

    public interface IModeService : IService<Mode>
    {
        List<Match> GenerateMatchesMode1(List<Team> equipos);
    }
}
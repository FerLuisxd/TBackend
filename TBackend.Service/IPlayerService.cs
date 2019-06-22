using TBackend.Entity;
using System.Collections.Generic;

namespace TBackend.Service
{

    public interface IPlayerService : IService<Player>
    {
        List<Player> getPlayersFromTeamId(int id);
    }
}
using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface IPlayerService : IService<Player>
    {
        List<Player> getPlayersFromTeamId(int id);
    }
}
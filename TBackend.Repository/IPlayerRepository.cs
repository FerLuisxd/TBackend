using TBackend.Entity;
using System.Collections.Generic;

namespace TBackend.Repository
{
    public interface IPlayerRepository: IRepository<Player>
    {
        List<Player> getPlayersFromTeamId(int id);
        IEnumerable<PlayerDto> getPlayers();
        PlayerDto getPlayer(int id);
    }
}
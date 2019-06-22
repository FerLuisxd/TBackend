using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class PlayerService : IPlayerService
    {

        private IPlayerRepository playerRepository;
        private ITeamService teamService;

        public PlayerService(IPlayerRepository playerRepository, ITeamService teamService)
        {
            this.playerRepository = playerRepository;
            this.teamService = teamService;
        }

        public bool Delete(int id)
        {
            return playerRepository.Delete(id);
        }

        public Player Get(int id)
        {
            return playerRepository.Get(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return playerRepository.GetAll();
        }

        public List<Player> getPlayersFromTeamId(int id)
        {
            return playerRepository.getPlayersFromTeamId(id);
        }

        public bool Save(Player entity)
        {
            if (entity.TeamId != null)
            {
                Team team = teamService.Get(entity.TeamId.GetValueOrDefault());
                team.NMembers = team.NMembers+1;
                teamService.Update(team);
            }
            return playerRepository.Save(entity);
        }

        public bool Update(Player entity)
        {
            return playerRepository.Update(entity);
        }
    }
}
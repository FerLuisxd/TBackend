using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class PlayerService : IPlayerService
    {

        private IPlayerRepository playerRepository;
        private ITeamRepository teamRepository;

        public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }

        public bool Delete(int id)
        {
            var player = playerRepository.Get(id);
            if(player.TeamId==null)
                return playerRepository.Delete(id);
            else 
                return false;
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
               
                    Team team = teamRepository.Get(entity.TeamId.GetValueOrDefault());
                    team.NMembers = team.NMembers + 1;
                    teamRepository.Update(team);
                //    }
            }
            return playerRepository.Save(entity);
        }

        public bool Update(Player entity)
        {
            
            Player old = this.Get(entity.Id);
            if (old.TeamId != null)
            {
                Team team = teamRepository.Get(old.TeamId.GetValueOrDefault());
                team.NMembers = team.NMembers - 1;
                teamRepository.Update(team);
                
            }
            if (entity.TeamId != null)
            {
                Team team = teamRepository.Get(entity.TeamId.GetValueOrDefault());
                team.NMembers = team.NMembers + 1;
                teamRepository.Update(team);
            }
            return playerRepository.Update(entity);
        }
    }
}
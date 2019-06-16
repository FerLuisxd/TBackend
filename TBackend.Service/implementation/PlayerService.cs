using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class PlayerService : IPlayerService
    {

        private IPlayerRepository playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository=playerRepository;
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

        public bool Save(Player entity)
        {
            return playerRepository.Save(entity);
        }

        public bool Update(Player entity)
        {
            return playerRepository.Update(entity);
        }
    }
}
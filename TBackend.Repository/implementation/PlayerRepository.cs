using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;

namespace TBackend.Repository.implementation
{
    public class PlayerRepository : IPlayerRepository
    {

        private ApplicationDbContext context;

        public PlayerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Player Get(int id)
        {
            var result = new Player();
            try
            {
                result = context.Players.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Player> GetAll()
        {

            var result = new List<Player>();
            try
            {
                result = context.Players.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Player entity)
        {
            try
            {

                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
            return true;
        }

        public bool Update(Player entity)//Nunca se actualizan.
        {
             try
            {
                 var PlayerOrigina = context.Players.Single(
                     x => x.Id == entity.Id
                 );

                 PlayerOrigina.Id=entity.Id;
                 PlayerOrigina.GamePreferences=entity.GamePreferences;
                 PlayerOrigina.TeamId=entity.TeamId;
                 PlayerOrigina.Name=entity.Name;

                 context.Update(PlayerOrigina);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Player> getPlayersFromTeamId(int id)
        {
            var result = new List<Player>();
            try
            {
                result = context.Players.Where(x=> x.TeamId == id).ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
    }
}
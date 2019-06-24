using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var obj = context.Players.Single(
                    x => x.Id == id
                );

                context.Players.Remove(obj);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

               throw;
            }
            return true;
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

        public IEnumerable<PlayerDto> getPlayers()
        {
            var result = context.Players
            .Include(t => t.Team)
            .ToList();

           return result.Select(o => new PlayerDto
            {
            Id = o.Id,
            GamePreferences = o.GamePreferences,
            Name = o.Name,
            Team = o.TeamId != null? o.Team : null ,
            TeamId = o.TeamId.GetValueOrDefault(),
            TeamName = o.TeamId != null? o.Team.Name : null,
        });
        }

        public PlayerDto getPlayer(int id)
        {
           var result = new PlayerDto();
            try
            {
                //result = context.Tournaments.Single(x => x.Id == id);
                var o = context.Players
            .Include(t => t.Team)
            .Single(x => x.Id == id);

                result.Id = o.Id;
                result.GamePreferences = o.GamePreferences;
                result.Name = o.Name;
                
                result.TeamId = o.TeamId.GetValueOrDefault();
                if(o.TeamId != null){
                    result.Team = o.Team;
                    result.TeamName = o.Team.Name;}
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
    }
}
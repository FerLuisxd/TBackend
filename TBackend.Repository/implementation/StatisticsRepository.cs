using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;
using TBackend.Repository.dto;
using Microsoft.EntityFrameworkCore;

namespace TBackend.Repository.implementation
{
    public class StatisticsRepository : IStatisticsRepository
    {

        private ApplicationDbContext context;

        public StatisticsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Statistics Get(int id)
        {
            var result = new Statistics();
            try
            {
                result = context.Statistics.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Statistics> GetAll()
        {

            var result = new List<Statistics>();
            try
            {
                result = context.Statistics.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Statistics entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Statistics entity)//Nunca se actualizan.
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<Statistics> FindAllStadistics(int id)
        {
            var result = new List<Statistics>();
            try
            {
                result = context.Statistics.Where(x => x.MatchId == id).ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<StatisticsDto> getAllStatistics()
        {
            var result = context.Statistics
            .Include(t => t.Player)
            .Include(t => t.Match)
            .ToList();

            return result.Select(o => new StatisticsDto
            {
               Id = o.Id,
               Assists = o.Assists,
               Damage = o.Damage,
               Deaths = o.Deaths,
               Kills = o.Kills,
               PlayerName = o.Player.Name,
               PlayerId = o.PlayerId,
               MatchId = o.MatchId,
               Match = o.Match
            });
        }

        public IEnumerable<StatisticsDto> getAllStatisticsMatchId(int id)
        {
            var result = context.Statistics
            .Include(t => t.Player)
            .Include(t => t.Match)
            .Where(x => x.MatchId == id)
            .ToList();

            return result.Select(o => new StatisticsDto
            {
               Id = o.Id,
               Assists = o.Assists,
               Damage = o.Damage,
               Deaths = o.Deaths,
               Kills = o.Kills,
               PlayerName = o.Player.Name,
               PlayerId = o.PlayerId,
               MatchId = o.MatchId,
               Match = o.Match
            });
        }

        public StatisticsDto getStatistic(int id)
        {
            var result = new StatisticsDto();
            try
            {
                //result = context.Tournaments.Single(x => x.Id == id);
                var o = context.Statistics
            .Include(t => t.Player)
            .Include(t => t.Match)
            .Single(x => x.Id == id);

                result.Id = o.Id;
                result.Assists = o.Assists;
                result.Damage = o.Damage;
                result.Deaths = o.Deaths;
                result.Kills = o.Kills;
                result.PlayerName = o.Player.Name;
                result.PlayerId = o.PlayerId;
                result.MatchId = o.MatchId;
                result.Match = o.Match;
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<StatisticsDto> getStatisticsPlayer(int id)
        {
             var result = context.Statistics
            .Include(t => t.Player)
            .Include(t => t.Match)
            .Where(x => x.PlayerId == id)
            .ToList();

            return result.Select(o => new StatisticsDto
            {
               Id = o.Id,
               Assists = o.Assists,
               Damage = o.Damage,
               Deaths = o.Deaths,
               Kills = o.Kills,
               PlayerName = o.Player.Name,
               PlayerId = o.PlayerId,
               MatchId = o.MatchId,
               Match = o.Match
            });
        }

        public IEnumerable<StatisticsDto> getStatisticParam(ParamsDto param)
        {
            var result = context.Statistics
            .Include(t => t.Player)
            .Include(t => t.Match)
            .Where(t => t.Assists >= param.Assists)
            .Where(t=>  t.Damage >= param.Assists)
            .Where(t=> t.Deaths >= param.Damage)
            .Where(t=> t.Kills>=param.Kills)
            .ToList();

            return result.Select(o => new StatisticsDto
            {
               Id = o.Id,
               Assists = o.Assists,
               Damage = o.Damage,
               Deaths = o.Deaths,
               Kills = o.Kills,
               PlayerName = o.Player.Name,
               PlayerId = o.PlayerId,
               MatchId = o.MatchId,
               Match = o.Match
            });
        }
    }
}
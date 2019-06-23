using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;
using TBackend.Repository.dto;
using Microsoft.EntityFrameworkCore;
using System;

namespace TBackend.Repository.implementation
{
    public class MatchRepository : IMatchRepository
    {

        private ApplicationDbContext context;

        public MatchRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Match Get(int id)
        {
            var result = new Match();
            try
            {
                result = context.Matchs.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Match> GetAll()
        {

            var result = new List<Match>();
            try
            {
                result = context.Matchs.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Match entity)
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

        public bool Update(Match entity)//Nunca se actualizan.
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<Match> FindAllMatches(int id)
        {

            var result = new List<Match>();
            try
            {
                result = context.Matchs.Where(x => x.TournamentId == id).ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
        public int ReturnTournamentId(int match_id)
        {
            var result = new Match();
            try
            {
                result = context.Matchs.Single(x => x.Id == match_id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result.TournamentId;
        }

        public IEnumerable<MatchDto> getMatchesTournamentId(int id)
        {
        var result = context.Matchs
         .Include(t => t.Tournament)
         .Include(t => t.Team1)
         .Include(t => t.Team2)
         .Include(t => t.Winner)
         .Where(t=>t.TournamentId==id)
         .ToList();

            return result.Select(o => new MatchDto
            {
            Id = o.Id,
            Fase = o.Fase,
            Team1Id = o.Team1Id.GetValueOrDefault(),
            Team2Id = o.Team2Id.GetValueOrDefault(),
            WinnerId = o.WinnerId.GetValueOrDefault(),
            WinnerName = o.Winner.Name,
            Team1Name = o.Team1.Name,
            Team2Name = o.Team2.Name,
            TournamentId = o.TournamentId,
            TournamentName = o.Tournament.Name
        });
        }
        public IEnumerable<MatchDto> getMatchesTeamId(int id)
        {
        var result = context.Matchs
         .Include(t => t.Tournament)
         .Include(t => t.Team1)
         .Include(t => t.Team2)
         .Include(t => t.Winner)
         .Where(t=>t.Team1Id==id||t.Team2Id==id)
         .ToList();

         return result.Select(o => new MatchDto
            {
            Id = o.Id,
            Fase = o.Fase,
            Team1Id = o.Team1Id.GetValueOrDefault(),
            Team2Id = o.Team2Id.GetValueOrDefault(),
            WinnerId = o.WinnerId.GetValueOrDefault(),
            WinnerName = o.Winner.Name,
            Team1Name = o.Team1.Name,
            Team2Name = o.Team2.Name,
            TournamentId = o.TournamentId,
            TournamentName = o.Tournament.Name
        });
        }

        public IEnumerable<MatchDto> getMatches()
        {
            var result = context.Matchs
         .Include(t => t.Tournament)
         .Include(t => t.Team1)
         .Include(t => t.Team2)
         .Include(t => t.Winner)
         .ToList();

           return result.Select(o => new MatchDto
            {
            Id = o.Id,
            Fase = o.Fase,
            Team1Id = o.Team1Id.GetValueOrDefault(),
            Team2Id = o.Team2Id.GetValueOrDefault(),
            WinnerId = o.WinnerId.GetValueOrDefault(),
            WinnerName = o.Winner.Name,
            Team1Name = o.Team1.Name,
            Team2Name = o.Team2.Name,
            TournamentId = o.TournamentId,
            TournamentName = o.Tournament.Name
        });

        }

    public MatchDto getMatch(int id)
    {
        var result = new MatchDto();
        try
        {
            //result = context.Tournaments.Single(x => x.Id == id);
            var o = context.Matchs
        .Include(t => t.Tournament)
        .Include(t => t.Team1)
        .Include(t => t.Team2)
        .Include(t => t.Winner)
        .Single(x => x.Id == id);

            result.Id = o.Id;
            result.Fase = o.Fase;
            result.Team1Id = o.Team1Id.GetValueOrDefault();
            result.Team2Id = o.Team2Id.GetValueOrDefault();
            result.WinnerId = o.WinnerId.GetValueOrDefault();
            // result.Name = o.Name;
            // result.Date = o.Date;
            // result.PlayerId = o.PlayerId;
            // result.PlayerName = o.Player.Name;
            // result.Teams = o.Teams;
            // result.NTeams = o.NTeams;
            result.WinnerName = o.Winner.Name;
            result.Team1Name = o.Team1.Name;
            result.Team2Name = o.Team2.Name;
            result.TournamentId = o.TournamentId;
            result.TournamentName = o.Tournament.Name;
        }

        catch (System.Exception)
        {

            throw;
        }
        return result;
    }
}
}
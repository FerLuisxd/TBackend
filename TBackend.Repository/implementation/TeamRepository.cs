using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;
using Microsoft.EntityFrameworkCore;
using System;

namespace TBackend.Repository.implementation
{
    public class TeamRepository : ITeamRepository
    {

        private ApplicationDbContext context;

        public TeamRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Team Get(int id)
        {
            var result = new Team();
            try
            {
                result = context.Teams.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Team> GetAll()
        {

            var result = new List<Team>();
            try
            {
                result = context.Teams.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Team entity)
        {
            try
            {
                if(entity.TournamentId ==null)
                    entity.TournamentId=null;
                Console.WriteLine("TournamentId");
                Console.WriteLine(entity.TournamentId);
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Team entity)
        {
            try
            {
                var TeamOrigina = context.Teams.Single(
                    x => x.Id == entity.Id
                );
                
                TeamOrigina.Id = entity.Id;
                TeamOrigina.NMembers = entity.NMembers;
                TeamOrigina.TournamentId = entity.TournamentId;
                TeamOrigina.Name = entity.Name;

                context.Update(TeamOrigina);
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
                var obj = context.Teams.Single(
                    x => x.Id == id
                );

                context.Teams.Remove(obj);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

               throw;
            }
            return true;
        }
        public List<Team> FindAllTeams(int id)
        {
            var result = new List<Team>();
            try
            {
                result = context.Teams.Where(x=> x.TournamentId == id).ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<TeamDto> GetAllTeams()
        {
          var result = context.Teams
            .Include(t => t.Tournament)
            .ToList();

           return result.Select(o => new TeamDto
            {
            Id = o.Id,
            NMembers = o.NMembers,
            Name = o.Name,
            Tournament = o.TournamentId!=null? o.Tournament:null,
            TournamentId = o.TournamentId.GetValueOrDefault(),
             TournamentName =o.TournamentId!=null? o.Tournament.Name:null
        });

        }

        public TeamDto getTeam(int id)
        {
            var result = new TeamDto();
            try
            {
                //result = context.Tournaments.Single(x => x.Id == id);
                var o = context.Teams
            .Include(t => t.Tournament)
            .Single(x => x.Id == id);

                result.Id = o.Id;
                result.NMembers = o.NMembers;
                result.Name = o.Name;
                result.TournamentId = o.TournamentId.GetValueOrDefault();
                if(o.TournamentId!=null){
                result.TournamentName = o.Tournament.Name;
                result.Tournament = o.Tournament;}
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
    }
}
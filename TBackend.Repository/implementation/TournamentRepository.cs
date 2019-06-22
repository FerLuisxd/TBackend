using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;
using Microsoft.EntityFrameworkCore;
using TBackend.Repository.dto;

namespace TBackend.Repository.implementation
{
    public class TournamentRepository : ITournamentRepository
    {

        private ApplicationDbContext context;

        public TournamentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Tournament Get(int id)
        {
            var result = new Tournament();
            try
            {
                result = context.Tournaments.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<TournamentDto> GetAllTournaments()
        {

               var  result = context.Tournaments
                .Include(t => t.Player )
                .Include(t=> t.Teams)
                .Include(t=> t.Mode)
                .ToList();

                return result.Select(o=> new TournamentDto{
                    Id=o.Id,
                    ModeId = o.ModeId,
                    ModeFormat= o.Mode.Format,
                    Winner = o.Winner,
                    Name = o.Name,
                    Date = o.Date,
                    PlayerId = o.PlayerId,
                    PlayerName = o.Player.Name,
                    Teams = o.Teams,
                    NTeams= o.NTeams
                });
            

           // return result;
        }

        public bool Save(Tournament entity)
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

        public bool Update(Tournament entity)
        {
            try
            {
                 var TournamentOrigina = context.Tournaments.Single(
                     x => x.Id == entity.Id
                 );

                 TournamentOrigina.Id=entity.Id;
                 TournamentOrigina.Winner=entity.Winner;
                 TournamentOrigina.ModeId=entity.ModeId;
                 TournamentOrigina.PlayerId=entity.PlayerId;
                 TournamentOrigina.Date=entity.Date;
                 TournamentOrigina.NTeams=entity.NTeams;
                 TournamentOrigina.Name=entity.Name;

                 context.Update(TournamentOrigina);
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
        public List<Tournament> FindHost(int id){
            
            var result = new List<Tournament>();
            try
            {
                result = context.Tournaments.Where(x=> x.PlayerId ==id).ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Tournament> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
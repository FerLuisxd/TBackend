using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;

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

        public IEnumerable<Tournament> GetAll()
        {

            var result = new List<Tournament>();
            try
            {
                result = context.Tournaments.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
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

                return false;
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

    }
}
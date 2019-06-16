using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;

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

    }
}
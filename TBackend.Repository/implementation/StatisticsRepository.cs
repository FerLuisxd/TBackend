using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;

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

    }
}
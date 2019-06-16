using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;

namespace TBackend.Repository.implementation
{
    public class ModeRepository : IModeRepository
    {

        private ApplicationDbContext context;

        public ModeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Mode Get(int id)
        {
            var result = new Mode();
            try
            {
                result = context.Modes.Single(x => x.Id == id);
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Mode> GetAll()
        {

            var result = new List<Mode>();
            try
            {
                result = context.Modes.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool Save(Mode entity)
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

        public bool Update(Mode entity)//Nunca se actualizan.
        {
               throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
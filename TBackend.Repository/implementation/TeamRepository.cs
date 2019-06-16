using System.Collections.Generic;
using System.Linq;
using TBackend.Entity;
using TBackend.Repository.context;

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

                 TeamOrigina.Id=entity.Id;
                 TeamOrigina.NMembers=entity.NMembers;
                 TeamOrigina.TournamentId=entity.TournamentId;
                 TeamOrigina.Name=entity.Name;

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
            throw new System.NotImplementedException();
        }

    }
}
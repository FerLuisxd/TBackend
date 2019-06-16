using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class TeamService : ITeamService
    {

        private ITeamRepository teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository=teamRepository;
        }
        
        public bool Delete(int id)
        {
            return teamRepository.Delete(id);
        }

        public Team Get(int id)
        {
            return teamRepository.Get(id);
        }

        public IEnumerable<Team> GetAll()
        {
           return teamRepository.GetAll();
        }

        public bool Save(Team entity)
        {
            return teamRepository.Save(entity);
        }

        public bool Update(Team entity)
        {
            return teamRepository.Update(entity);
        }
    }
}
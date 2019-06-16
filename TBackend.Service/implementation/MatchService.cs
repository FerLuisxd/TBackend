using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class MatchService : IMatchService
    {

        private IMatchRepository matchRepository;
        public MatchService(IMatchRepository matchRepository)
        {
            this.matchRepository=matchRepository;
        }
        
        public bool Delete(int id)
        {
            return matchRepository.Delete(id);
        }

        public Match Get(int id)
        {
            return matchRepository.Get(id);
        }

        public IEnumerable<Match> GetAll()
        {
           return matchRepository.GetAll();
        }

        public bool Save(Match entity)
        {
            return matchRepository.Save(entity);
        }

        public bool Update(Match entity)
        {
            return matchRepository.Update(entity);
        }
    }
}
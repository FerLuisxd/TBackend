using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repositoy;

namespace TBackend.Service.implementation
{
    public class MatchService : IMatchService
    {

        private IMatchRepository MatchRepository;
        public MatchService(IMatchRepository MatchRepository)
        {
            this.MatchRepository = MatchRepository;
        }
        
        public Match Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Match> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Match entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Match entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
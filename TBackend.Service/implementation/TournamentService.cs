using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class TournamentService : ITournamentService
    {

        private ITournamentRepository tournamentRepository;
        public TournamentService(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository=tournamentRepository;
        }
        
        public bool Delete(int id)
        {
            return tournamentRepository.Delete(id);
        }

        public Tournament Get(int id)
        {
            return tournamentRepository.Get(id);
        }

        public IEnumerable<Tournament> GetAll()
        {
           return tournamentRepository.GetAll();
        }

        public bool Save(Tournament entity)
        {
            return tournamentRepository.Save(entity);
        }

        public bool Update(Tournament entity)
        {
            return tournamentRepository.Update(entity);
        }
    }
}
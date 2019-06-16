using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class ModeService : IModeService
    {

        private IModeRepository modeRepository;
        public ModeService(IModeRepository modeRepository)
        {
            this.modeRepository=modeRepository;
        }
        
        public bool Delete(int id)
        {
            return modeRepository.Delete(id);
        }

        public Mode Get(int id)
        {
            return modeRepository.Get(id);
        }

        public IEnumerable<Mode> GetAll()
        {
           return modeRepository.GetAll();
        }

        public bool Save(Mode entity)
        {
            return modeRepository.Save(entity);
        }

        public bool Update(Mode entity)
        {
            return modeRepository.Update(entity);
        }
    }
}
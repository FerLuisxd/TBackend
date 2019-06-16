using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;

namespace TBackend.Service.implementation
{
    public class StatisticsService : IStatisticsService
    {

        private IStatisticsRepository statisticsRepository;
        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            this.statisticsRepository=statisticsRepository;
        }
        
        public bool Delete(int id)
        {
            return statisticsRepository.Delete(id);
        }

        public Statistics Get(int id)
        {
            return statisticsRepository.Get(id);
        }

        public IEnumerable<Statistics> GetAll()
        {
           return statisticsRepository.GetAll();
        }

        public bool Save(Statistics entity)
        {
            return statisticsRepository.Save(entity);
        }

        public bool Update(Statistics entity)
        {
            return statisticsRepository.Update(entity);
        }
    }
}
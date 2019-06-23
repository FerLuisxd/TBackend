using System.Collections.Generic;
using TBackend.Entity;
using TBackend.Repository;
using TBackend.Repository.dto;

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

        public IEnumerable<StatisticsDto> getAllStatistics()
        {
            return statisticsRepository.getAllStatistics();
        }

        public IEnumerable<StatisticsDto> getAllStatisticsMatchId(int id)
        {
            return statisticsRepository.getAllStatisticsMatchId(id);
        }

        public StatisticsDto getStatistic(int id)
        {
            return statisticsRepository.getStatistic(id);
        }

        public IEnumerable<StatisticsDto> getStatisticsPlayer(int id)
        {
            return statisticsRepository.getStatisticsPlayer(id);
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
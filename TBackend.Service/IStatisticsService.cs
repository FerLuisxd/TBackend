using TBackend.Entity;
using System.Collections.Generic;
using TBackend.Repository.dto;

namespace TBackend.Service
{

    public interface IStatisticsService : IService<Statistics>
    {
        IEnumerable<StatisticsDto> getAllStatistics();
        IEnumerable<StatisticsDto> getAllStatisticsMatchId(int id);
        StatisticsDto getStatistic(int id);
    }
}
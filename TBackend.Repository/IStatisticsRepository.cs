using TBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBackend.Repository.dto;

namespace TBackend.Repository
{
    public interface IStatisticsRepository : IRepository<Statistics>
    {
        List<Statistics> FindAllStadistics(int id);
        IEnumerable<StatisticsDto> getAllStatistics();
        IEnumerable<StatisticsDto> getAllStatisticsMatchId(int id);
        StatisticsDto getStatistic(int id);
    }
}
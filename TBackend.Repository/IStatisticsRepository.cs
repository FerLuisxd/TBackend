using TBackend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBackend.Repository
{
    public interface IStatisticsRepository: IRepository<Statistics>
    {
        List<Statistics> FindAllStadistics(int id);
    }
}
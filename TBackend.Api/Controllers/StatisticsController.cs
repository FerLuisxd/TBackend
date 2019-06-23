using TBackend.Entity;
using TBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace TBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {

        private IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                statisticsService.getAllStatistics()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                statisticsService.getStatistic(id)
            );
        }
        [HttpGet("tournament/{id}")]
        public ActionResult getStatistic(int id)
        {
            return Ok(
                statisticsService.getAllStatisticsMatchId(id)
            );
        }
        [HttpPost]
        public ActionResult Post([FromBody] Statistics statistics)
        {
            return Ok(
                statisticsService.Save(statistics)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Statistics statistics)
        {
            return Ok(
                statisticsService.Update(statistics)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                statisticsService.Delete(id)
            );
        }

    }
}
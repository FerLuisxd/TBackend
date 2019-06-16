using TBackend.Entity;
using TBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace TBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {

        private IMatchService matchService;

        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                matchService.GetAll()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                matchService.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Match match)
        {
            return Ok(
                matchService.Save(match)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Match match)
        {
            return Ok(
                matchService.Update(match)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                matchService.Delete(id)
            );
        }

    }
}
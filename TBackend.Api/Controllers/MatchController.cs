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
                matchService.getAllMaches()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                matchService.getOneMatch(id)
            );
        }

        [HttpGet("tournament/{id}")]
        public ActionResult getTournamentMatch(int id)
        {
            return Ok(
                matchService.getMatchesTournamentId(id)
            );
        }
        [HttpGet("team/{id}")]
        public ActionResult getTeam(int id)
        {
            return Ok(
                matchService.getMatchesTeamId(id)
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
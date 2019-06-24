using TBackend.Entity;
using TBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace TBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private IPlayerService tournamentService;

        public PlayerController(IPlayerService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                tournamentService.getPlayers()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                tournamentService.getPlayer(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Player tournament)
        {
            return Ok(
                tournamentService.Save(tournament)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Player tournament)
        {
            return Ok(
                tournamentService.Update(tournament)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                tournamentService.Delete(id)
            );
        }

    }
}
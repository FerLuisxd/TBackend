using TBackend.Entity;
using TBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace TBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private ITournamentService tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                tournamentService.GetAllTournaments()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                tournamentService.GetOneTournament(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Tournament tournament)
        {
            return Ok(
                tournamentService.Save(tournament)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Tournament tournament)
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
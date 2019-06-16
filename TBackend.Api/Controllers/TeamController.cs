using TBackend.Entity;
using TBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace TBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                teamService.GetAll()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                teamService.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Team team)
        {
            return Ok(
                teamService.Save(team)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Team team)
        {
            return Ok(
                teamService.Update(team)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                teamService.Delete(id)
            );
        }

    }
}
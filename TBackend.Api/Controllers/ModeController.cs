using TBackend.Entity;
using TBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace TBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeController : ControllerBase
    {

        private IModeService modeService;

        public ModeController(IModeService modeService)
        {
            this.modeService = modeService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                modeService.GetAll()
            );
        }
         [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(
                modeService.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Mode mode)
        {
            return Ok(
                modeService.Save(mode)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Mode mode)
        {
            return Ok(
                modeService.Update(mode)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                modeService.Delete(id)
            );
        }

    }
}
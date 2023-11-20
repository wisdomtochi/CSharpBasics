using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly LogicLayer logicLayer;

        public PeopleController(LogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await logicLayer.ReadAll();
            return Ok(result);
        }
    }
}

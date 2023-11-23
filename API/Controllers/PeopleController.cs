using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly LogicLayer logicLayer;
        private readonly HttpClient httpClient;

        public PeopleController(LogicLayer logicLayer)
        {
            httpClient = new HttpClient();
            this.logicLayer = logicLayer;
        }

        public async Task<IActionResult> GetAsync(string uri)
        {
            //HttpClient client = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using HttpResponseMessage message = await httpClient.GetAsync(uri);
            if (message.IsSuccessStatusCode)
            {
                return Ok(await message.Content.ReadAsStringAsync());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await logicLayer.ReadAll();
            return Ok(result);
        }
    }
}

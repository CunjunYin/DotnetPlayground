using Microsoft.AspNetCore.Mvc;
using Laboratory.Models;


namespace Laboratory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet(Name = "jwkts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<String> Get([FromQuery] TestModel model)
        {

            if(ModelState.IsValid) {
                return "OK";
            }
            return "Not OK";
        }
    }
}
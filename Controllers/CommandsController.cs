using Microsoft.AspNetCore.Mvc;

namespace VersedApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public sealed class CommandsController : ControllerBase
    {

        [HttpGet]
        public string Index()
        {
            return "welcome to my api";
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using VersedApi.Models;

namespace VersedApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public sealed class CommandsController : ControllerBase
    {
        private readonly ICommandsService _service;

        public CommandsController(ICommandsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Command>> GetCommands()
        {
            var commandsList = _service.GetCommands();
            if (commandsList.Count == 0)
            {
                return NoContent();
            }
            return Ok(commandsList);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetById(int id)
        {
            var command = _service.GetCommandById(id);
            if (command != null)
            {
                return Ok(command);
            }

            return NotFound();
        }

        [HttpGet("{platform}/1")]
        public ActionResult<List<Command>> GetByPlatform(string platform)
        {
            var commands = _service.GetCommand(platform);
            if (commands != null)
            {
                return Ok(commands);
            }
            return NotFound();
        }

        // [HttpPost]
        // public ActionResult AddCommand(Command newCommand)
        // {
        //     var result = _service.AddCommand(newCommand);
        //     if (result)
        //     {
        //         return Ok();
        //     }

        //     return CreatedAtRoute(nameof(""),);

        // }


    }
}
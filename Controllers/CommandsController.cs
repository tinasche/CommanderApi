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

        [HttpGet("{id}", Name = "GetById")]
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

        [HttpPost]
        public ActionResult<Command> AddCommand(Command newCommand)
        {
            var result = _service.AddCommand(newCommand);
            if (!result)
            {
                throw new ArgumentNullException(nameof(newCommand));
            }
            return CreatedAtAction(nameof(GetById), new { Id = newCommand.Id }, newCommand);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var deleteStatus = _service.DeleteCommand(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult EditCommand(int id, Command commandToEdit)
        {
            var editStatus = _service.EditCommand(id, commandToEdit);
            if (editStatus)
            {
                return Ok();
            } else {
                return BadRequest();
            }

        }


    }
}
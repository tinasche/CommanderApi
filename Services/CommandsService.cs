using VersedApi.Data;
using VersedApi.Models;

namespace VersedApi.Services
{

    public class CommandsService : ICommandsService
    {
        private readonly CommandsContext _context;

        public CommandsService(CommandsContext context)
        {
            _context = context;
        }
        public bool AddCommand(Command newCommand)
        {
            if (newCommand != null)
            {
                _context.Commands.Add(newCommand);
                _context.SaveChanges();

                return true;
            } else
            {
                return false;
            }

        }

        public void DeleteCommand(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCommand(int id, Command editCommand)
        {
            throw new NotImplementedException();
        }

        public List<Command> GetCommand(string byPlatform)
        {
            var commands = _context.Commands.Where<Command>(c => c.Platform == byPlatform);
            return commands.ToList<Command>();
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.Find(id);
            return command;
        }

        public List<Command> GetCommands()
        {
            return _context.Commands.ToList<Command>();
        }
    }
}
#nullable disable

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
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCommand(int id)
        {
            var commmandToRemove = _context.Commands.FirstOrDefault(c => c.Id == id);
            if (commmandToRemove != null)
            {
                _context.Commands.Remove(commmandToRemove);
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool EditCommand(int id, Command editedCommand)
        {
            try
            {
                var commandToEdit = this.GetCommandById(id);

                commandToEdit.CommandString = editedCommand.CommandString;
                commandToEdit.Description = editedCommand.Description;
                commandToEdit.Platform = editedCommand.Platform;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Command> GetCommand(string byPlatform)
        {
            var commands = _context.Commands.Where<Command>(c => c.Platform == byPlatform);
            return commands.ToList<Command>();

            // return await _context.Commands.AllAsync(c => c.Platform == byPlatform);
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public List<Command>  GetCommands()
        {
            return _context.Commands.ToList<Command>();
        }

        public bool PatchCommand(int id, Command patchCommand)
        {
            throw new NotImplementedException();
        }
    }
}
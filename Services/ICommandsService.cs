using VersedApi.Models;

namespace VersedApi.Services
{
    public interface ICommandsService
    {
        public List<Command> GetCommands();
        public List<Command> GetCommand(string byPlatform);
        public Command GetCommandById(int id);
        public bool AddCommand(Command newCommand);
        public void EditCommand(int id, Command editCommand);
        public void DeleteCommand(int id);
        // TODO: Implement the patch method
    }
}
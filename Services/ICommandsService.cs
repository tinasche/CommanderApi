namespace VersedApi.Services;
public interface ICommandsService
{
    public List<Command> GetCommands();
    public List<Command> GetCommand(string byPlatform);
    public Command GetCommandById(int id);
    public bool AddCommand(Command newCommand);
    public bool EditCommand(int id, Command editCommand);
    public bool DeleteCommand(int id);
    public bool PatchCommand(int id, Command patchCommand);
}

namespace VersedApi.Data;

public sealed class CommandsContext : DbContext
{
    public CommandsContext(DbContextOptions<CommandsContext> options) : base(options) {}

    public DbSet<Command> Commands { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Command>().HasData(
            new Command { Id=1, CommandString="dotnet watch run", Description="executes dotnet with 'watch' parameter for file changes and reload", Platform="dotnet"},
            new Command { Id=2, CommandString="dotnet build", Description="build the current project/solution", Platform="dotnet"},
            new Command { Id=3, CommandString="npm init vue@latest", Description="start a new vue project", Platform="vuejs"}
        );
    }

}
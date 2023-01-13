using Microsoft.EntityFrameworkCore;
using VersedApi.Models;

namespace VersedApi.Data;

public sealed class CommandsContext : DbContext
{
    public CommandsContext(IConfiguration configuration)
    {
        _configurator = configuration;
    }
    DbSet<Command> Commands;
    private IConfiguration _configurator;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configurator.GetConnectionString("CommandConn")).UseCamelCaseNamingConvention();
        // optionsBuilder.UseNpgsql("host=localhost;user=tinashe;password=P3trificus;database=CommanderDb").UseCamelCaseNamingConvention();
    }
}
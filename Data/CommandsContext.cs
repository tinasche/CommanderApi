using Microsoft.EntityFrameworkCore;
using VersedApi.Models;

namespace VersedApi.Data;

public sealed class CommandsContext : DbContext
{
    private IConfiguration _configurator;
    public CommandsContext(IConfiguration configuration) => _configurator = configuration;
    DbSet<Command> Commands;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_configurator.GetConnectionString("CommandConn")).UseCamelCaseNamingConvention();
}
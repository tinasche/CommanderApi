global using VersedApi.Services;
using Microsoft.EntityFrameworkCore;
using VersedApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CommandsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CommandConn")).UseCamelCaseNamingConvention());
builder.Services.AddScoped<ICommandsService, CommandsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();

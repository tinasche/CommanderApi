global using VersedApi.Services;
using Microsoft.EntityFrameworkCore;
using VersedApi.Data;

var builder = WebApplication.CreateBuilder(args);
var MyAllowedOrigins = "_myAllowedOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://commander-he41em2mi-tinasche.vercel.app/", "https://commander-app.vercel.app/");
    });
});
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CommandsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CosmosConn")).UseCamelCaseNamingConvention());
builder.Services.AddScoped<ICommandsService, CommandsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(MyAllowedOrigins);

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();

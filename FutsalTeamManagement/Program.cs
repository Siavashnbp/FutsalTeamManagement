using FustalTeamManagement.Services.Player;
using FustalTeamManagement.Services.Team;
using FustalTeamManagement.Services.TeamPlayer;
using FutsalTeamManagement.Contracts;
using FutsalTeamManagement.Persistence.EF;
using FutsalTeamManagement.Persistence.EF.Player;
using FutsalTeamManagement.Persistence.EF.Team;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<PlayerServices, PlayerAppServices>();
builder.Services.AddScoped<PlayerRepository, EFPlayerRepository>();
builder.Services.AddScoped<TeamServices, TeamAppServices>();
builder.Services.AddScoped<TeamRepository, EFTeamRepository>();
builder.Services.AddScoped<TeamPlayerServices, TeamPlayerAppServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

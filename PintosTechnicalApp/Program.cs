using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PintosTechnicalApp;
using PintosTechnicalApp.Config;
using PintosTechnicalApp.Config.Seeds;
using PintosTechnicalApp.DTOs;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PlayerPostDTO>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(
"CorsPolicy",
builder =>
{
    builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await Migrations(scope.ServiceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();

async Task Migrations(IServiceProvider services)
{
    bool applymigrations = configuration.GetValue<bool>("Migrations:ApplyMigrations");
    bool applyseed = configuration.GetValue<bool>("Migrations:ApplySeed");
    string connection = configuration.GetValue<string>("ConnectionStrings:MySQLConnection")!;
    var context = services.GetRequiredService<AppDbContext>();

    if (applymigrations)
    {
        context.Database.Migrate();
    }

    if (applyseed)
    {
        await StadiumSeed.AddStadiums(context);
        await TeamSeed.AddTeams(context);
        await PlayerSeed.AddPlayers(context);
        await TrainerSeed.AddTrainers(context);
    }
}
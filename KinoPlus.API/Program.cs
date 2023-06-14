using KinoPlus.API.Extensions;
using KinoPlus.API.Middleware;
using KinoPlus.Services.Data;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddBearerAuthentication(builder.Configuration);
builder.Services.AddSwaggerWithAuthorization();

builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<KinoplusContext>();
    var recommendationService = services.GetRequiredService<IRecommendationService>();
    var imageService = services.GetRequiredService<IImageService>();

    await context.Database.MigrateAsync();
    await Seed.SeedEntities(context);
    await Seed.SeedImages(context, imageService);

    await recommendationService.CreateModel();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during seed");
}

await app.RunAsync();

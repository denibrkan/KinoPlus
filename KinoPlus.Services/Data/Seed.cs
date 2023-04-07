using KinoPlus.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KinoPlus.Services.Data
{
    public class Seed
    {
        public static async Task SeedEntities(KinoplusContext db)
        {
            if (!await db.Roles.AnyAsync())
            {
                var roleData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Roles.json");
                var roles = JsonSerializer.Deserialize<List<Role>>(roleData);
                if (roles == null) return;

                await db.AddRangeAsync(roles);
            }
            if (!await db.Users.AnyAsync())
            {
                var usersData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Users.json");
                var users = JsonSerializer.Deserialize<List<User>>(usersData);
                if (users == null) return;

                await db.AddRangeAsync(users);

                await db.SaveChangesAsync();
            }
            if (!await db.UserRoles.AnyAsync())
            {
                var userRoleData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/UserRoles.json");
                var userRoles = JsonSerializer.Deserialize<List<UserRole>>(userRoleData);
                if (userRoles == null) return;

                await db.AddRangeAsync(userRoles);
            }
            if (!await db.ProjectionTypes.AnyAsync())
            {
                var projectionTypeData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/ProjectionTypes.json");
                var projectionTypes = JsonSerializer.Deserialize<List<ProjectionType>>(projectionTypeData);
                if (projectionTypes == null) return;

                await db.AddRangeAsync(projectionTypes);
            }
            if (!await db.Categories.AnyAsync())
            {
                var categorieData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categorieData);
                if (categories == null) return;

                await db.AddRangeAsync(categories);
            }
            if (!await db.Actors.AnyAsync())
            {
                var actorData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Actors.json");
                var actors = JsonSerializer.Deserialize<List<Actor>>(actorData);
                if (actors == null) return;

                await db.AddRangeAsync(actors);
            }
            if (!await db.Genres.AnyAsync())
            {
                var genreData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Genres.json");
                var genres = JsonSerializer.Deserialize<List<Genre>>(genreData);
                if (genres == null) return;

                await db.AddRangeAsync(genres);
            }
            if (!await db.Years.AnyAsync())
            {
                var yearData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Years.json");
                var years = JsonSerializer.Deserialize<List<Year>>(yearData);
                if (years == null) return;

                await db.AddRangeAsync(years);
            }
            if (!await db.MovieStatuses.AnyAsync())
            {
                var statusData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Statuses.json");
                var statuses = JsonSerializer.Deserialize<List<MovieStatus>>(statusData);
                if (statuses == null) return;

                await db.AddRangeAsync(statuses);
            }
            if (!await db.Halls.AnyAsync())
            {
                var hallData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Halls.json");
                var halls = JsonSerializer.Deserialize<List<Hall>>(hallData);
                if (halls == null) return;

                await db.AddRangeAsync(halls);
            }
            if (!await db.Countries.AnyAsync())
            {
                var countryData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Countries.json");
                var countries = JsonSerializer.Deserialize<List<Country>>(countryData);
                if (countries == null) return;

                await db.AddRangeAsync(countries);
                await db.SaveChangesAsync();
            }
            if (!await db.Cities.AnyAsync() && await db.Countries.AnyAsync())
            {
                var cityData = await System.IO.File.ReadAllTextAsync("../KinoPlus.Services/Data/Seed/Cities.json");
                var cities = JsonSerializer.Deserialize<List<City>>(cityData);
                if (cities == null) return;

                await db.AddRangeAsync(cities);
            }

            await db.SaveChangesAsync();
        }
    }
}

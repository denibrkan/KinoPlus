using KinoPlus.Services;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace KinoPlus.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddDbContext<KinoplusContext>(
                options => options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            services.AddAutoMapper(typeof(Program));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieStatusService, MovieStatusService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IYearService, YearService>();
            services.AddScoped<IProjectionService, ProjectionService>();
            services.AddScoped<IProjectionTypeService, ProjectionTypeService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IWeekDayService, WeekDayService>();
            services.AddScoped<IMovieReactionService, MovieReactionService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFITPasosService, FITPasosService>();
        }

        public static void AddBearerAuthentication(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["TokenKey"]!)
                        ),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public static void AddSwaggerWithAuthorization(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description =
                            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                    }
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    }
                );
            });
        }
    }
}

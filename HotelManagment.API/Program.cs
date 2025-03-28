using HotelManagment.API.MIddleware;
using HotelManagment.Models.Dtos.Idenitity;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Data;
using HotelManagment.Repository.Implementations;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Service.Implementations;
using HotelManagment.Service.Interfaces;
using HotelManagment.Service.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelManagment.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services
                .AddDbContext<ApplicationDbContext>(options => options
                .ConfigureWarnings(warning => warning.Ignore(RelationalEventId.PendingModelChangesWarning))
                .UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
            
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IGuestRepository, GuestRepository>();
            builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IGuestBookingRepository, GuestBookingRepository>();

            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();
            builder.Services.AddScoped<IGuestService, GuestService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            builder.Services.AddScoped<IAuthService, AuthService>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;

                //options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));


            /// <summary>
            /// Authentication
            /// </summary>
            var secret = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Secret");
            var issuer = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Issuer");
            var audience = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Audience");
            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = issuer,
                    ValidAudience = audience
                };
            });




            var app = builder.Build();

            app.CreateDatabaseAutomatically();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapOpenApi();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

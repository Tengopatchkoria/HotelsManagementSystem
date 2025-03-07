
using HotelManagment.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=ANCARAMESSI\\SQLEXPRESS;Database=HotelManagmentBase;Trusted_Connection=true;TrustServerCertificate=true"));

            var app = builder.Build();

            app.MapOpenApi();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

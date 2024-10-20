
using CarParking.DataBase.Context;
using CarParking.DataBase.Interfaces;
using CarParking.DataBase.Repositories;
using CarParking.Models;
using CarParking.Services;
using CarParking.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarParking
{
    public class Program
    {
        public const string _CONNECTION_STRING_EnvNAME = "DEFAULT_PARKING_CONNECTION";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Подключение базы данных
            string? connectionString = Environment.GetEnvironmentVariable(_CONNECTION_STRING_EnvNAME);
            builder.Services.AddDbContext<DbContext, ParkingDbContext>(options => 
                options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
            builder.Services.AddScoped<IParkingService, ParkingService>();
            builder.Services.AddScoped<IPasswordHasher<UserDatum>, PasswordHasher<UserDatum>>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

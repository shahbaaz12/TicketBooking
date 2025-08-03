
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TicketBooking.Extensions;
using TicketBooking.Models.EntityContext;
using TicketBooking.Services;

namespace TicketBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add DbContext for Entity Framework Core
            builder.Services.AddDbContext<TicketBookingContext>(
                options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("TBContext") ??
                    throw new InvalidOperationException("Connection string 'TbContext' not found.")));

            // Extension method to register application services
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}


//OPEN API URL          : https://localhost:7251/openapi/v1.json
//SWAGGER UI URL        : https://localhost:7251/swagger/index.html
//SWAGGER RAW JSON URL  : https://localhost:7251/swagger/v1/swagger.json
// File: Extensions/ServiceCollectionExtensions.cs
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Models.EntityContext;
using TicketBooking.Repositories;
using TicketBooking.Repositories.Contracts;
using TicketBooking.Services;
using TicketBooking.Services.Contracts; // your service namespaces

namespace TicketBooking.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
             

            // Add more as needed
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ITheaterService, TheaterService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IShowService, ShowService>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();
        }
    }
}

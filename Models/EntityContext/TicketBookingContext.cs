using Microsoft.EntityFrameworkCore;

namespace TicketBooking.Models.EntityContext
{
    public class TicketBookingContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowSeat> ShowSeats { get; set; }
        public DbSet<ShowSeatType> ShowSeatTypes { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<User> Users { get; set; }

        public TicketBookingContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
            // Connection string using AttachDbFilename
            var connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TicketBookingDb;Integrated Security=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}

 
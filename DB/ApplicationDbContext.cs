using Microsoft.EntityFrameworkCore;
using BookingSystem.Models;

namespace BookingSystem.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EventEaseDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<BookingSummary> BookingSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingSummary>().HasNoKey().ToView("View_BookingSummary");

            // Clear mapping for Bookings to avoid double-columns
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(b => b.EventType).WithMany().HasForeignKey(b => b.EventTypeID).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(b => b.Venue).WithMany().HasForeignKey(b => b.VenueID).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(b => b.Event).WithMany().HasForeignKey(b => b.EventID).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }

}

//Kamil Mrzygód Azure for Developers Second Edition Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions
//Implementing search functionality in asp net mvc - A guide by Computer Experts - https://youtu.be/DsRaOeTVr94?si=AeyWk9_kwAtUbI7b
//Gemini, 2026 
using Microsoft.EntityFrameworkCore;
using Reservations.Repository.Domain;

namespace Reservations.Repository.Contexts
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base (options)
        {
            
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

    }
}

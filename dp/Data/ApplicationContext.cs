using dp.Data.Models;
using dp.Models;
using Microsoft.EntityFrameworkCore;

namespace dp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<TicketCart> TicketCarts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options) { }

    }
}

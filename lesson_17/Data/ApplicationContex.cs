using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson_25.Data
{
    public class ApplicationContex : DbContext
    {

        public DbSet<Author> Authors { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<Book> Books { get; set; }


        public ApplicationContex(DbContextOptions<ApplicationContex> options) : base (options)
        { }

    }
}

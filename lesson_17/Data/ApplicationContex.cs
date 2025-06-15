using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson_25.Data
{
    public class ApplicationContex : DbContext
    {

        public DbSet<Author> Authors;

        public DbSet<Reader> Readers;

        public DbSet<Book> Books;


        public ApplicationContex(DbContextOptions<ApplicationContex> options) : base (options)
        { }

        public ApplicationContex()
        {

        }

    }
}

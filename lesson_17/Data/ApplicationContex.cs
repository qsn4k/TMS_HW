using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson_25.Data
{
    public class ApplicationContex : DbContext
    {

        DbSet<Author> Authors;

        DbSet<Reader> Readers;

        DbSet<Book> Books;


        public ApplicationContex(DbContextOptions<ApplicationContex> options) : base (options)
        { }

    }
}

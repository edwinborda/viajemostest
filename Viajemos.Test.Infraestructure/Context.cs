using Microsoft.EntityFrameworkCore;
using Viajemos.Test.Book.Domain;
using BookDomain = Viajemos.Test.Book.Domain.Book;
using Viajemos.Test.Book.Infraestructure.Configuration;

namespace Viajemos.Test.Book.Infraestructure
{
    public class Context: DbContext
    {
        public Context(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }
        public DbSet<BookDomain> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new AuthorHasBookConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new EditorialConfiguration());
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajemos.Test.Book.Domain;

namespace Viajemos.Test.Book.Infraestructure.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id)
                .HasMaxLength(10);
            builder.Property(it => it.Name)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(it => it.Lastname)
                .IsRequired()
                .HasMaxLength(45);

          
        }
    }
}

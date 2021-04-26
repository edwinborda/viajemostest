using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viajemos.Test.Book.Domain;

namespace Viajemos.Test.Book.Infraestructure.Configuration
{
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id)
                .HasMaxLength(10);
            builder.Property(it => it.Name)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(it => it.Campus)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}

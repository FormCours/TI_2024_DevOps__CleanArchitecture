using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCleanArchitecture.Infrastructure.Database.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            // Table
            builder.ToTable("Author");

            // Keys
            builder.HasKey(a => a.Id)
                .HasName("PK_Author")
                .IsClustered();

            // Columns
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(a => a.Pseudo)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(a => a.BirthDate)
                .HasColumnType("date");

            // Indexes
            builder.HasIndex(a => new { a.LastName, a.FirstName })
                .HasDatabaseName("IDX_Author__Name");
        }
    }
}

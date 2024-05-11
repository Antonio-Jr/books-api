using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder
            .HasOne(a => a.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(fk => fk.AuthorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Category)
            .WithMany(b => b.Books)
            .HasForeignKey(fk => fk.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("books");
    }
}
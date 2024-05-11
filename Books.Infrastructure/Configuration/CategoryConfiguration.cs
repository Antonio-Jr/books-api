using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder
            .HasMany(b => b.Books)
            .WithOne(c => c.Category)
            .HasForeignKey(b => b.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("categories");
    }
}
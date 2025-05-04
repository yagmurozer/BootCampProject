
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Concrete.EntityFramework.EntityConfigurations;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamps");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").ValueGeneratedOnAdd();

        builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

        builder.Property(b => b.InstructorId).HasColumnName("InstructorId").IsRequired();

        builder.Property(b => b.StartDate).HasColumnName("StartDate").IsRequired();

        builder.Property(b => b.EndDate).HasColumnName("EndDate").IsRequired();

        builder.Property(b => b.BootcampState).HasColumnName("BootcampState").IsRequired().HasConversion<string>();
    }
}

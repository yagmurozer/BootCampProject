
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Concrete.EntityFramework.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");
        builder.Property(i => i.CompanyName).HasMaxLength(100).IsRequired();
        builder.HasMany(i => i.Bootcamps).WithOne(b => b.Instructor).HasForeignKey(b => b.InstructorId);
    }
}

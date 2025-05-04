
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Concrete.EntityFramework.EntityConfigurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");
        builder.HasKey(a => a.Id); // primary key i var

        builder.Property(a => a.Id).HasColumnName("Id").ValueGeneratedOnAdd();

        builder.Property(a => a.ApplicantId).HasColumnName("ApplicantId").IsRequired();

        builder.Property(a => a.BootcampId).HasColumnName("BootcampId").IsRequired();

        builder.Property(a => a.ApplicationState).HasColumnName("ApplicationState").IsRequired().HasConversion<string>();

        builder.HasOne(a => a.Applicant).WithMany(app => app.Applications).HasForeignKey(a => a.ApplicantId);

        builder.HasOne(a => a.Bootcamp).WithMany(b => b.Applications).HasForeignKey(a => a.BootcampId);
    }
}

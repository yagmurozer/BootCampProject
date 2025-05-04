
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Concrete.EntityFramework.EntityConfigurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.ToTable("Applicants"); // dbsetlere göre tabloları oluşturur fakat kullanılan database çeşidine göre isimlendirme değişebilir. O yüzden configurasyon tanımlandı


        builder.Property(a => a.About).HasMaxLength(100);
        builder.HasMany(a => a.Applications).WithOne(app => app.Applicant).HasForeignKey(app => app.ApplicantId);
    }
}

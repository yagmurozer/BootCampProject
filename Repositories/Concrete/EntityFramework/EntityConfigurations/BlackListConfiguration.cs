
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.Concrete.EntityFramework.EntityConfigurations;

public class BlackListConfiguration : IEntityTypeConfiguration<BlackList>
{
    public void Configure(EntityTypeBuilder<BlackList> builder)
    {
        builder.ToTable("Blacklists");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").ValueGeneratedOnAdd(); 

        builder.Property(b => b.Reason).HasColumnName("Reason").HasMaxLength(500).IsRequired();

        builder.Property(b => b.Date).HasColumnName("Date").IsRequired();

        builder.Property(b => b.ApplicantId).HasColumnName("ApplicantId").IsRequired();

    }
}

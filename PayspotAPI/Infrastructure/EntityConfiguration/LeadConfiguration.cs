using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PayspotAPI.Infrastructure.EntityConfiguration;
public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("Leads")
        .HasKey(x => x.Id);
    }
}
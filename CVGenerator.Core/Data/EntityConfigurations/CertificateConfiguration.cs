using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class CertificateConfiguration : BaseConfiguration<Certificate, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("certificates");

            builder.Property(x => x.Name).HasColumnType("varchar(400)").IsRequired();
            builder.Property(x => x.ExternalId).HasColumnType("bigint");
        }
    }
}

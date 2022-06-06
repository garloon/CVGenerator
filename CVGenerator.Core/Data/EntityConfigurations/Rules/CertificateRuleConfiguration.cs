using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations.Rules
{
    public class CertificateRuleConfiguration : BaseConfiguration<CertificateRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<CertificateRule> builder)
        {
            builder.ToTable("certificate_rules");

            builder.Property(x => x.IsShow);

            builder
                .HasOne(e => e.CvSettings)
                .WithMany(s => s.CertificateRules)
                .HasForeignKey(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}
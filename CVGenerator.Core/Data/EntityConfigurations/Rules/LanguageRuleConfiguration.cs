using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations.Rules
{
    public class LanguageRuleConfiguration : BaseConfiguration<LanguageRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<LanguageRule> builder)
        {
            builder.ToTable("language_rules");

            builder.Property(x => x.LanguageLevel);

            builder.Property(x => x.IsShow);

            builder
                .HasOne(e => e.Language)
                .WithMany()
                .HasForeignKey(c => c.LanguageId)
                .IsRequired();

            builder
                .HasOne(e => e.CvSettings)
                .WithMany(s => s.LanguageRules)
                .HasForeignKey(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}

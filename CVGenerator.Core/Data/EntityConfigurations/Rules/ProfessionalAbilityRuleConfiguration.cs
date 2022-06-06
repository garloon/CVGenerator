using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations.Rules
{
    public class ProfessionalAbilityRuleConfiguration : BaseConfiguration<ProfessionalAbilityRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<ProfessionalAbilityRule> builder)
        {
            builder.ToTable("professional_ability_rules");

            builder.Property(x => x.IsShow);

            builder
                .HasOne(e => e.CvSettings)
                .WithMany(s => s.ProfessionalAbilityRules)
                .HasForeignKey(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}
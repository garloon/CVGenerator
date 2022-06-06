using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations.Rules
{
    public class EducationRuleConfiguration : BaseConfiguration<EducationRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EducationRule> builder)
        {
            builder.ToTable("education_rules");

            builder.Property(x => x.IsShow);

            builder
                .HasOne(e => e.Education)
                .WithMany()
                .HasForeignKey(c => c.EducationId)
                .IsRequired();

            builder
                .HasOne(e => e.CvSettings)
                .WithMany(s => s.EducationRules)
                .HasForeignKey(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}

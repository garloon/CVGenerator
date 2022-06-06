using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations.Rules
{
    public class HardSkillRuleConfiguration : BaseConfiguration<HardSkillRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<HardSkillRule> builder)
        {
            builder.ToTable("hard_skill_rules");

            builder.Property(x => x.IsShow);

            builder
                .HasOne(e => e.HardSkill)
                .WithMany()
                .HasForeignKey(c => c.HardSkillId)
                .IsRequired();

            builder
                .HasOne(e => e.CvSettings)
                .WithMany(s => s.HardSkillRules)
                .HasForeignKey(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}
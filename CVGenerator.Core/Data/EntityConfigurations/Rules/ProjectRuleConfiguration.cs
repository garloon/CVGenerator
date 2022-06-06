using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations.Rules
{
    public class ProjectRuleConfiguration : BaseConfiguration<ProjectRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<ProjectRule> builder)
        {
            builder.ToTable("project_rules");

            builder.Property(x => x.IsShow).IsRequired();

            builder.Property(c => c.ShowName).HasColumnType("varchar(200)").IsRequired();
            builder.Property(c => c.MyTasks).HasColumnType("varchar(3000)").IsRequired();
            builder.Property(c => c.DescriptionProject).HasColumnType("varchar(3000)").IsRequired();
            builder.Property(c => c.StartDate).HasColumnType("timestamp").IsRequired();
            builder.Property(c => c.EndDate).HasColumnType("timestamp").IsRequired();

            builder
                .HasOne(e => e.ProjectRole)
                .WithMany()
                .HasForeignKey(c => c.ProjectRoleId)
                .IsRequired();

            builder
                .HasOne(e => e.CvSettings)
                .WithMany(s => s.ProjectRules)
                .HasForeignKey(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}
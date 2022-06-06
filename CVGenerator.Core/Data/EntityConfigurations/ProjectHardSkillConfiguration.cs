using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class ProjectHardSkillConfiguration : BaseConfiguration<ProjectHardSkill, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<ProjectHardSkill> builder)
        {
            builder.ToTable("project_hard_skills");

            builder
                .HasOne(c => c.Project)
                .WithMany(u => u.HardSkills)
                .HasForeignKey(c => c.ProjectId)
                .IsRequired();

            builder
                .HasOne(c => c.HardSkill)
                .WithMany(u => u.Projects)
                .HasForeignKey(c => c.HardSkillId)
                .IsRequired();
        }
    }
}
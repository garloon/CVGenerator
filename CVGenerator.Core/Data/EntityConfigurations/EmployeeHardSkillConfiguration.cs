using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeHardSkillConfiguration : BaseConfiguration<EmployeeHardSkill, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeHardSkill> builder)
        {
            builder.ToTable("employee_hard_skills");

            builder.Property(x => x.ExternalId).HasColumnType("bigint");
            builder.Property(x => x.AbilityLevel);

            builder
                .HasOne(c => c.Employee)
                .WithMany(u => u.HardSkills)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.HardSkill)
                .WithMany(u => u.Employees)
                .HasForeignKey(c => c.HardSkillId)
                .IsRequired();
        }
    }
}
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeEducationConfiguration : BaseConfiguration<EmployeeEducation, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeEducation> builder)
        {
            builder.ToTable("employee_educations");

            builder
                .HasOne(c => c.Employee)
                .WithMany(u => u.Educations)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.Education)
                .WithMany(u => u.Employees)
                .HasForeignKey(c => c.EducationId)
                .IsRequired();
        }
    }
}

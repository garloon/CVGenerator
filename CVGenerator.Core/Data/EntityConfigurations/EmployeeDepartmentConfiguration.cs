using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeDepartmentConfiguration : BaseConfiguration<EmployeeDepartment, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.ToTable("employee_departments");

            builder
                .HasOne(c => c.Employee)
                .WithMany(u => u.Departments)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.Department)
                .WithMany(u => u.Employees)
                .HasForeignKey(c => c.DepartmentId)
                .IsRequired();
        }
    }
}
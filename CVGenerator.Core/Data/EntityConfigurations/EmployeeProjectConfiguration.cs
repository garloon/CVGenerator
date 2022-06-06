using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeProjectConfiguration : BaseConfiguration<EmployeeProject, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("employee_projects");

            builder.Property(c => c.StartDate).HasColumnType("timestamp").IsRequired();
            builder.Property(c => c.EndDate).HasColumnType("timestamp").IsRequired();
            builder.Property(c => c.MyTasks).HasColumnType("varchar(3000)");
            builder.Property(c => c.DescriptionProject).HasColumnType("varchar(3000)");
            builder.Property(c => c.ShowName).HasColumnType("varchar(200)");

            builder
                .HasOne(c => c.ProjectRole)
                .WithMany(u => u.Projects)
                .HasForeignKey(c => c.ProjectRoleId);

            builder
                .HasOne(c => c.Employee)
                .WithMany(u => u.Projects)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.Project)
                .WithMany(u => u.Employees)
                .HasForeignKey(c => c.ProjectId)
                .IsRequired();
        }
    }
}
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeConfiguration : BaseConfiguration<Employee, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder.Property(x => x.FirstName).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.MiddleName).HasColumnType("varchar(150)");
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(60)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.ExternalId).HasColumnType("bigint");
        }
    }
}
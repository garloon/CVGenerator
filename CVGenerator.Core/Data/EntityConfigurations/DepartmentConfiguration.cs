using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class DepartmentConfiguration : BaseConfiguration<Department, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Department> builder)
        {
			builder.ToTable("departments");

			builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.IsApplicationDepartment).HasDefaultValue(false);
            builder.Property(x => x.IsForCv).HasDefaultValue(false);
            builder.Property(x => x.ExternalId).HasColumnType("varchar(150)");
		}
    }
}
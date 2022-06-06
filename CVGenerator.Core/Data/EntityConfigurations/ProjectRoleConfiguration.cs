using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class ProjectRoleConfiguration : BaseConfiguration<ProjectRole, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<ProjectRole> builder)
        {
            builder.ToTable("project_roles");

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.ShortName).HasColumnType("varchar(15)").IsRequired();
        }
    }
}

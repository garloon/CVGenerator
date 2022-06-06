using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class ProjectConfiguration : BaseConfiguration<Project, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(c => c.StartDate).HasColumnType("timestamp");
            builder.Property(c => c.Description).HasColumnType("varchar(3000)");
            builder.Property(c => c.EndDate).HasColumnType("timestamp");
        }
    }
}

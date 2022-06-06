using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EducationConfiguration : BaseConfiguration<Education, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("educations");

            builder.Property(x => x.UniversityName).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.SpecialtyName).HasColumnType("varchar(150)");
            builder.Property(x => x.TypeSpecialty);
            builder.Property(c => c.BeginDate);
            builder.Property(c => c.FinishDate);
        }
    }
}

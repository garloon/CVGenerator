using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class ProfessionalAbilityConfiguration : BaseConfiguration<ProfessionalAbility, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<ProfessionalAbility> builder)
        {
            builder.ToTable("professional_abilities");

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.SectionId).HasColumnType("bigint");
            builder.Property(x => x.PositionId).HasColumnType("bigint");
        }
    }
}

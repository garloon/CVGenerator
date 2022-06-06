using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class HardSkillConfiguration : BaseConfiguration<HardSkill, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<HardSkill> builder)
        {
            builder.ToTable("hard_skills");

            builder.Property(x => x.Code).HasColumnType("varchar(200)");
            builder.Property(x => x.Title).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Type).HasColumnType("varchar(200)");
            builder.Property(x => x.IsActual);
            builder.Property(x => x.IsUsed);
            builder.Property(x => x.Level);
            builder.Property(x => x.ParentId).HasColumnType("bigint");
            builder.Property(x => x.ExternalId).HasColumnType("bigint");
        }
    }
}
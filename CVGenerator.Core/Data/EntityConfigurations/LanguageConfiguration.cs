using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class LanguageConfiguration : BaseConfiguration<Language, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("languages");

            builder.Property(x => x.Name).HasColumnType("varchar(150)").IsRequired();
        }
    }
}

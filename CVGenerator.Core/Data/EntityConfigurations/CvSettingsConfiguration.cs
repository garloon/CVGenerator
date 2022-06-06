using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class CvSettingsConfiguration : BaseConfiguration<CvSettings, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<CvSettings> builder)
        {
            builder.ToTable("cv_settings");

            builder
                .HasOne(s => s.Cv)
                .WithOne(ad => ad.CvSettings)
                .HasForeignKey<Cv>(ad => ad.CvSettingsId);
        }
    }
}

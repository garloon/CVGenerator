using System;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class TemporaryReferenceConfiguration : BaseConfiguration<TemporaryReference, Guid>
	{
        protected override void ConfigureCustom(EntityTypeBuilder<TemporaryReference> builder)
        {
			builder.ToTable("temporaries_references");

			builder.Property(x => x.NumberDownloads).HasColumnType("bigint").IsRequired();
			builder.Property(x => x.ExpirationTimeout).HasColumnType("timestamp").IsRequired();

			builder
				.HasOne(t => t.Cv)
				.WithMany(c => c.TemporaryReferences)
				.HasForeignKey(t => t.CvId)
				.IsRequired();
		}
    }
}
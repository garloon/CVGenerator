using System;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class CvConfiguration : BaseConfiguration<Cv, Guid>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Cv> builder)
        {
            builder.ToTable("cv");

            builder.Property(x => x.Name).HasColumnType("varchar(350)").IsRequired();
            builder.Property(x => x.DepartmentName).HasColumnType("varchar(150)").IsRequired();

            builder
                .HasOne(s => s.Employee)
                .WithMany(e => e.Cvs)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.CvSettings)
                .WithOne(s => s.Cv)
                .HasForeignKey<Cv>(c => c.CvSettingsId)
                .IsRequired();
        }
    }
}

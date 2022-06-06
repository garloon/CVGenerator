using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeCertificateConfiguration : BaseConfiguration<EmployeeCertificate, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeCertificate> builder)
        {
            builder.ToTable("employee_certificates");

            builder.Property(x => x.ExternalId).HasColumnType("bigint");

            builder
                .HasOne(c => c.Employee)
                .WithMany(u => u.Certificates)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.Certificate)
                .WithMany(u => u.Employees)
                .HasForeignKey(c => c.CertificateId)
                .IsRequired();
        }
    }
}
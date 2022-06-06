using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeLanguageConfiguration : BaseConfiguration<EmployeeLanguage, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeLanguage> builder)
        {
            builder.ToTable("employee_languages");

            builder.Property(x => x.LanguageLevel);

            builder
                .HasOne(c => c.Employee)
                .WithMany(u => u.Languages)
                .HasForeignKey(c => c.EmployeeId)
                .IsRequired();

            builder
                .HasOne(c => c.Language)
                .WithMany(u => u.Employees)
                .HasForeignKey(c => c.LanguageId)
                .IsRequired();
        }
    }
}
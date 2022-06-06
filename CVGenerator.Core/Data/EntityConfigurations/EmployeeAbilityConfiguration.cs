using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVGenerator.Core.Data.EntityConfigurations
{
    public class EmployeeAbilityConfiguration : BaseConfiguration<EmployeeProfessionalAbility, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<EmployeeProfessionalAbility> builder)
        {
            builder.ToTable("employee_abilities");
        }
    }
}

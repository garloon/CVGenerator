using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeAbilityRepository : BaseRepository<EmployeeProfessionalAbility, long, GeneratorContext, EmployeeAbilityFilter>, IEmployeeProfessionalAbilityRepository
    {
        public EmployeeAbilityRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

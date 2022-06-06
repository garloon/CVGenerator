using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, long, GeneratorContext, EmployeeFilter>, IEmployeeRepository
    {
        public EmployeeRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

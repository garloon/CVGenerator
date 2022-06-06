using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeDepartmentRepository : BaseRepository<EmployeeDepartment, long, GeneratorContext, EmployeeDepartmentFilter>, IEmployeeDepartmentRepository
    {
        public EmployeeDepartmentRepository(GeneratorContext context)
          : base(context)
        {
        }
    }
}
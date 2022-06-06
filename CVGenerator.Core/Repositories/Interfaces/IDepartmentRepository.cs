using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department, long, GeneratorContext, DepartmentFilter>
    {
    }
}

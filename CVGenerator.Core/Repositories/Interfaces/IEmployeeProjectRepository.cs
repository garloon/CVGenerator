using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface IEmployeeProjectRepository : IBaseRepository<EmployeeProject, long, GeneratorContext, EmployeeProjectFilter>
    {
    }
}
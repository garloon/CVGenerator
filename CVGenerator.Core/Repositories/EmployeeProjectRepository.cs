using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeProjectRepository : BaseRepository<EmployeeProject, long, GeneratorContext, EmployeeProjectFilter>, IEmployeeProjectRepository
    {
        public EmployeeProjectRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

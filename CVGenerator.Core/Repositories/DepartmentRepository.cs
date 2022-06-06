using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, long, GeneratorContext, DepartmentFilter>, IDepartmentRepository
    {
        public DepartmentRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

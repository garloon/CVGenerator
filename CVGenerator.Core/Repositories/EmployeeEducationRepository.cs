using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeEducationRepository : BaseRepository<EmployeeEducation, long, GeneratorContext, EmployeeEducationFilter>, IEmployeeEducationRepository
    {
        public EmployeeEducationRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

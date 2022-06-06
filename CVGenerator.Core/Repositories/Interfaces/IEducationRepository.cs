using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface IEducationRepository : IBaseRepository<Education, long, GeneratorContext, EducationFilter>
    {
    }
}

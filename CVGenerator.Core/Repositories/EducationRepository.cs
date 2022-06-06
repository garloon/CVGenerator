using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EducationRepository : BaseRepository<Education, long, GeneratorContext, EducationFilter>, IEducationRepository
    {
        public EducationRepository(GeneratorContext context)
          : base(context)
        {
        }
    }
}

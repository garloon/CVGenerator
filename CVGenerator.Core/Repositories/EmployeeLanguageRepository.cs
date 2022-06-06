using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeLanguageRepository : BaseRepository<EmployeeLanguage, long, GeneratorContext, EmployeeLanguageFilter>, IEmployeeLanguageRepository
    {
        public EmployeeLanguageRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

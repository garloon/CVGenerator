using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class LanguageRepository : BaseRepository<Language, int, GeneratorContext, LanguageFilter>, ILanguageRepository
    {
        public LanguageRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class CvSettingsRepository : BaseRepository<CvSettings, long, GeneratorContext, CvSettingsFilter>, ICvSettingsRepository
    {
        public CvSettingsRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

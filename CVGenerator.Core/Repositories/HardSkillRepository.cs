using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Repositories
{
    public class HardSkillRepository : BaseRepository<HardSkill, long, GeneratorContext, HardSkillFilter>, IHardSkillRepository
    {
        public HardSkillRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}
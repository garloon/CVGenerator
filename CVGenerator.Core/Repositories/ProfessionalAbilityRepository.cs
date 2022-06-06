using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class ProfessionalAbilityRepository : BaseRepository<ProfessionalAbility, long, GeneratorContext, ProfessionalAbilityFilter>, IProfessionalAbilityRepository
    {
        public ProfessionalAbilityRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core.Repositories.Rules
{
    public class ProfessionalAbilityRuleRepository : BaseRepository<ProfessionalAbilityRule, long, GeneratorContext, ProfessionalAbilityRuleFilter>, IProfessionalAbilityRuleRepository
    {
        public ProfessionalAbilityRuleRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

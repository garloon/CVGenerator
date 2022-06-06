using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core.Repositories.Rules
{
    public class HardSkillRuleRepository : BaseRepository<HardSkillRule, long, GeneratorContext, HardSkillRuleFilter>, IHardSkillRuleRepository
    {
        public HardSkillRuleRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

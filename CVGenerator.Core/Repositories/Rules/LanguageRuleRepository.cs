using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core.Repositories.Rules
{
    public class LanguageRuleRepository : BaseRepository<LanguageRule, long, GeneratorContext, LanguageRuleFilter>, ILanguageRuleRepository
    {
        public LanguageRuleRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;

namespace CVGenerator.Core.Repositories.Interfaces.Rules
{
    public interface ILanguageRuleRepository : IBaseRepository<LanguageRule, long, GeneratorContext, LanguageRuleFilter>
    {
    }
}

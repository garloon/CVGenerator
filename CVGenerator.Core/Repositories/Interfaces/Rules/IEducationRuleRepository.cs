using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;

namespace CVGenerator.Core.Repositories.Interfaces.Rules
{
    public interface IEducationRuleRepository : IBaseRepository<EducationRule, long, GeneratorContext, EducationRuleFilter>
    {
    }
}

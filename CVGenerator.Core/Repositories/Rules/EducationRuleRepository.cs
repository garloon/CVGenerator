using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core.Repositories.Rules
{
    public class EducationRuleRepository : BaseRepository<EducationRule, long, GeneratorContext, EducationRuleFilter>, IEducationRuleRepository
    {
        public EducationRuleRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

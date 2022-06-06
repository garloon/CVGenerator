using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core.Repositories.Rules
{
    public class ProjectRuleRepository : BaseRepository<ProjectRule, long, GeneratorContext, ProjectRuleFilter>, IProjectRuleRepository
    {
        public ProjectRuleRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}
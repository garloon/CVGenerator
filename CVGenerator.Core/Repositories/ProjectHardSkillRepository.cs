using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class ProjectHardSkillRepository : BaseRepository<ProjectHardSkill, long, GeneratorContext, ProjectHardSkillFilter>, IProjectHardSkillRepository
    {
        public ProjectHardSkillRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}
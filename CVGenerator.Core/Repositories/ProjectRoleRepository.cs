using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class ProjectRoleRepository : BaseRepository<ProjectRole, int, GeneratorContext, ProjectRoleFilter>, IProjectRoleRepository
    {
        public ProjectRoleRepository(GeneratorContext context)
           : base(context)
        {
        }
    }
}

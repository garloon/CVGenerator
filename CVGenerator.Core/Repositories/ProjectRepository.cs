using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class ProjectRepository : BaseRepository<Project, long, GeneratorContext, ProjectFilter>, IProjectRepository
    {
        public ProjectRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

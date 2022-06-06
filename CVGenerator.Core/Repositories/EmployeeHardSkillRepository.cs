using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeHardSkillRepository : BaseRepository<EmployeeHardSkill, long, GeneratorContext, EmployeeHardSkillFilter>, IEmployeeHardSkillRepository
    {
        public EmployeeHardSkillRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}
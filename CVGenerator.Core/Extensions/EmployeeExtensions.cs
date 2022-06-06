using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Extensions
{
    public static class EmployeeExtensions
    {
        public static async Task<Employee> GetAllEmployeeDetails(this IEmployeeRepository repository, long employeeId)
        { 
            return await repository.GetFirstOrDefaultAsync(new EmployeeFilter(employeeId)
            {
                IncludeDepartments = true,
                IncludeHardSkills = true,
                IncludeProfessionalAbilities = true,
                IncludeEducations = true,
                IncludeLanguages = true,
                IncludeProjects = true,
                IncludeCertificates = true
            });
        }
    }
}
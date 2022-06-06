using CVGenerator.Core.Models.External;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CVGenerator.Core.RequestHelper
{
    public interface IRequestHelper
    {
        Task<List<ExternalEmployee>> GetEmployeesAsync();
        Task<List<ExternalDepartment>> GetDepartmentsAsync();
        Task<List<ExternalCertificate>> GetCertificatesAsync();
        Task<List<ExternalHardSkill>> GetHardSkillsAsync();
        Task<List<ExternalHardSkill>> GetHardSkillTreeAsync();
        Task<List<ExternalProject>> GetProjectsAsync();
        Task<ExternalEmployee> GetEmployeeAsync(long employeeId);
        Task<List<ExternalEmployeeCertificate>> GetEmployeeCertificateAsync(long employeeId);
        Task<List<ExternalEmployeeHardSkill>> GetEmployeeHardSkillAsync(long employeeId);
    }
}

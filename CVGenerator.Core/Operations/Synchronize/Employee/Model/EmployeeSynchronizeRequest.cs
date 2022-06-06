using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.Employee
{
    public class EmployeeSynchronizeRequest
    {
        public ExternalEmployee ExternalEmployee { get; set; }
        public List<ExternalEmployeeCertificate> ExternalEmployeeCertificates { get; set; }
        public List<ExternalEmployeeHardSkill> ExternalEmployeeHardSkills { get; set; }
    }
}

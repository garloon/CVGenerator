using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Operations.Synchronize.Employee
{
    public class EmployeeSynchronizeModel
    {
        public Data.Entities.Employee OurEmployee { get; set; }
        public List<EmployeeCertificate> OurEmployeeCertificates { get; set; }
        public List<EmployeeDepartment> OurEmployeeDepartment { get; set; }
        public List<EmployeeHardSkill> OurEmployeeHardSkills { get; set; }
        public List<EmployeeProject> OurEmployeeProjects { get; set; }
    }
}

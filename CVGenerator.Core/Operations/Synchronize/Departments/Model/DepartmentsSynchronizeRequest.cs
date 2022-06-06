using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.Departments
{
    public class DepartmentsSynchronizeRequest
    {
        public List<ExternalDepartment> ExternalDepartments { get; set; }
    }
}

using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.Employees
{
    public class EmployeesSynchronizeRequest
    {
        public List<ExternalEmployee> ExternalEmployees { get; set; }
    }
}

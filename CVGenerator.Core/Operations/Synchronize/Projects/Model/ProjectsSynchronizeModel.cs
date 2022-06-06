using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Operations.Synchronize.Projects
{
    // TODO: Другое название
    public class ProjectsSynchronizeModel
    {
        public List<Data.Entities.Employee> OurEmployees { get; set; }
        public List<Project> OurProjects { get; set; }
        public List<EmployeeProject> OurEmployeesProjects { get; set; }
    }
}

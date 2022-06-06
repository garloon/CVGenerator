using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.Projects
{
    public class ProjectsSynchronizeRequest
    {
        public List<ExternalProject> ExternalProjects { get; set; }
    }
}

using CVGenerator.Core.Operations.Synchronize.Certificates;
using CVGenerator.Core.Operations.Synchronize.Departments;
using CVGenerator.Core.Operations.Synchronize.HardSkills;
using CVGenerator.Core.Operations.Synchronize.Employees;
using CVGenerator.Core.Operations.Synchronize.Projects;
using CVGenerator.Core.Operations.Synchronize.Employee;
using Microsoft.Extensions.Logging;
using CVGenerator.Core.Operations.Cv.Generate;

namespace CVGenerator.Core.Operations
{
    public class CvOperations : ICvOperations
    {
        private readonly IGeneratorRepository _repository;
        private readonly ILogger<CvOperations> _logger;
        
        public CvOperations(
            IGeneratorRepository repository,
            ILogger<CvOperations> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public IOperation<CertificatesSynchronizeRequest> CreateCertificatesSynchronizeOperation()
        {
            return new CertificatesSynchronizeOperation(_repository, _logger);
        }

        public IOperation<DepartmentsSynchronizeRequest> CreateDepartmentsSynchronizeOperation()
        {
            return new DepartmentsSynchronizeOperation(_repository, _logger);
        }

        public IOperation<EmployeesSynchronizeRequest> CreateEmployeesSynchronizeOperation()
        {
            return new EmployeesSynchronizeOperation(_repository, _logger);
        }

        public IOperation<EmployeeSynchronizeRequest> CreateEmployeeSynchronizeOperation()
        {
            return new EmployeeSynchronizeOperation(_repository, _logger);
        }

        public IOperation<GenerateRequest, GenerateResponse> CreateGenerateOperation()
        {
            return new GenerateOperation(_repository, _logger, new CvRulesBuilder(_repository));
        }

        public IOperation<HardSkillsSynchronizeRequest> CreateHardSkillSynchronizeOperation()
        {
            return new HardSkillsSynchronizeOperation(_repository, _logger);
        }

        public IOperation<ProjectsSynchronizeRequest> CreateProjectsSynchronizeOperation()
        {
            return new ProjectsSynchronizeOperation(_repository, _logger);
        }
    }
}

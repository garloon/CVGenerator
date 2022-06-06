using CVGenerator.Core.Operations.Synchronize.Certificates;
using CVGenerator.Core.Operations.Synchronize.Departments;
using CVGenerator.Core.Operations.Synchronize.HardSkills;
using CVGenerator.Core.Operations.Synchronize.Employees;
using CVGenerator.Core.Operations.Synchronize.Projects;
using CVGenerator.Core.Operations.Synchronize.Employee;
using CVGenerator.Core.Operations.Cv.Generate;

namespace CVGenerator.Core.Operations
{
    /// <summary>
    /// Операции по работе с CV Генератором
    /// </summary>
    public interface ICvOperations
    {
        /// <summary>
        /// Операция по синхронизации проектов
        /// </summary>
        IOperation<ProjectsSynchronizeRequest> CreateProjectsSynchronizeOperation();

        /// <summary>
        /// Операция по синхронизации навыков сотрудников
        /// </summary>
        IOperation<HardSkillsSynchronizeRequest> CreateHardSkillSynchronizeOperation();

        /// <summary>
        /// Операция по синхронизации пользователей
        /// </summary>
        IOperation<EmployeesSynchronizeRequest> CreateEmployeesSynchronizeOperation();

        /// <summary>
        /// Операция по синхронизации конкретного пользователя
        /// </summary>
        IOperation<EmployeeSynchronizeRequest> CreateEmployeeSynchronizeOperation();

        /// <summary>
        /// Операция синхронизации отделов
        /// </summary>
        IOperation<DepartmentsSynchronizeRequest> CreateDepartmentsSynchronizeOperation();

        /// <summary>
        /// Операция по синхронизации сертификатов
        /// </summary>
        IOperation<CertificatesSynchronizeRequest> CreateCertificatesSynchronizeOperation();

        /// <summary>
        /// Операция по генерации резюме
        /// </summary>
        IOperation<GenerateRequest, GenerateResponse> CreateGenerateOperation();
    }
}
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;
using CVGenerator.Core.Operations;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Operations.Synchronize.Employees;
using CVGenerator.Core.Operations.Synchronize.Employee;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices
{
    /// <summary>
    /// Сервис по работе с cинхронизацией данных сотрудников
    /// </summary>
    public class SynchronizeEmployeeService : ISynchronizeEmployeeService
    {
        private readonly ILogger _logger;
        private readonly ICvOperations _operations;
        private readonly IRequestHelper _requestHelper;

        public SynchronizeEmployeeService(
            IRequestHelper requestHelper,
            ICvOperations operations,
            ILogger logger)
        {
            _requestHelper = requestHelper;
            _operations = operations;
            _logger = logger;
        }

        public async Task SynchronizeEmployeesAsync()
        {
            try
            {
                _logger.LogInformation("Началась синхронизация данных \"Сотрудники\"");

                var externalEmployees = await _requestHelper.GetEmployeesAsync();

                var requestModel = new EmployeesSynchronizeRequest { ExternalEmployees = externalEmployees };

                var operation = _operations.CreateEmployeesSynchronizeOperation();
                await operation.Execute(requestModel);

                _logger.LogInformation("Данные по сотрудникам синхронизированы");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"При синхронизации данных \"Сотрудники\" возникла ошибка: {ex.Message}");
            }
        }

        public async Task SynchronizeEmployeeAsync(long employeeId)
        {
            try
            {
                _logger.LogInformation($"Началась синхронизация данных \"Сотрудника ID: {employeeId}\"");

                var externalEmployee = await _requestHelper.GetEmployeeAsync(employeeId);
                var externalEmployeeCertificate = await _requestHelper.GetEmployeeCertificateAsync(employeeId);
                var externalEmployeeHardSkill = await _requestHelper.GetEmployeeHardSkillAsync(employeeId);

                var requestModel = new EmployeeSynchronizeRequest
                {
                    ExternalEmployee = externalEmployee,
                    ExternalEmployeeCertificates = externalEmployeeCertificate,
                    ExternalEmployeeHardSkills = externalEmployeeHardSkill,
                };

                var operation = _operations.CreateEmployeeSynchronizeOperation();
                await operation.Execute(requestModel);

                _logger.LogInformation("Данные по сотрудникам синхронизированы");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"При синхронизации данных \"Сотрудники\" возникла ошибка: {ex.Message}");
            }
        }
    }
}
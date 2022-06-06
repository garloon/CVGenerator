using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;
using CVGenerator.Core.Operations;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Operations.Synchronize.Departments;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices
{
    public class SynchronizeDepartmentService : ISynchronizeDepartmentService
    {
        private readonly ILogger _logger;
        private readonly ICvOperations _operations;
        private readonly IRequestHelper _requestHelper;

        public SynchronizeDepartmentService(
            IRequestHelper requestHelper,
            ICvOperations operations,
            ILogger logger)
        {
            _requestHelper = requestHelper;
            _operations = operations;
            _logger = logger;
        }

        /// <summary>
        /// Синхронизация направлений компании сотрудника из ME
        /// </summary>
        public async Task SynchronizeDepartmentsAsync()
        {
            try
            {
                _logger?.LogInformation("Началась синхронизация данных \"Направление\"");

                //TODO: Тут может падать из-за авторизации на ME, временно так
                var externalDepartments = await _requestHelper.GetDepartmentsAsync();

                var requestModel = new DepartmentsSynchronizeRequest { ExternalDepartments = externalDepartments };

                var operation = _operations.CreateDepartmentsSynchronizeOperation();
                await operation.Execute(requestModel);

                _logger?.LogInformation("Данные по направлениям синхрониированы");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"При синхронизации данных \"Направление\" возникла ошибка: {ex.Message}");
            }
        }
    }
}

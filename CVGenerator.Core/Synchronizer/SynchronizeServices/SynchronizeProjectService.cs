using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Operations;
using CVGenerator.Core.Operations.Synchronize.Projects;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices
{
    /// <summary>
    /// Сервис по работе с cинхронизацией проектов из ME
    /// </summary>
    public class SynchronizeProjectService : ISynchronizeProjectService
    {
        private readonly ILogger _logger;
        private readonly IRequestHelper _requestHelper;
        private readonly ICvOperations _operations;

        public SynchronizeProjectService(
            IRequestHelper requestHelper,
            ICvOperations operations,
            ILogger logger)
        {
            _logger = logger;
            _requestHelper = requestHelper;
            _operations = operations;
        }

        public async Task SynchronizeProjectsAsync()
        {
            try
            {
                _logger?.LogInformation("Началась синхронизация данных \"Проекты\"");

                var externalProjects = await _requestHelper.GetProjectsAsync();

                var requestModel = new ProjectsSynchronizeRequest { ExternalProjects = externalProjects };

                var operation = _operations.CreateProjectsSynchronizeOperation();
                await operation.Execute(requestModel);

                _logger?.LogInformation("Данные по проектам синхронизированы");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"При синхронизации данных \"Проекты\" возникла ошибка: {ex.Message}");
            }
        }
    }
}

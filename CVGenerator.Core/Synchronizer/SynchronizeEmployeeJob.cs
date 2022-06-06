using CVGenerator.Core.Synchronizer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer
{
    public class SynchronizeEmployeeJob : IBaseSyncService
    {
        private readonly ILogger<SynchronizeEmployeeJob> _logger;
        private readonly ISynchronizeFactory _synchronizeRepository;

        public SynchronizeEmployeeJob(ILogger<SynchronizeEmployeeJob> logger, ISynchronizeFactory synchronizeRepository)
        {
            _logger = logger;
            _synchronizeRepository = synchronizeRepository;
        }

        public async Task<Exception> RunAsync()
        {
            return await MainJob();
        }

        private async Task<Exception> MainJob()
        {
            try
            {
                _logger.LogInformation("Фоновый процесс синхронизациий сотрудников запущен");
                var x = _synchronizeRepository.CreateSynchronizeEmployeeService();
                await x.SynchronizeEmployeesAsync();

                _logger.LogInformation("Фоновый процесс синхронизациий сотрудников окончен");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Фоновый процесс синхронизациий сотрудников вызвал ошибку: {e.Message}");
                throw;
            }
        }
    }
}

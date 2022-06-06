using CVGenerator.Core.Synchronizer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer
{
    public class SynchronizeDepartmentJob : IBaseSyncService
    {
        private readonly ILogger<SynchronizeDepartmentJob> logger;
        private readonly ISynchronizeFactory synchronizeRepository;

        public SynchronizeDepartmentJob(ILogger<SynchronizeDepartmentJob> logger, ISynchronizeFactory synchronizeRepository)
        {
            this.logger = logger;
            this.synchronizeRepository = synchronizeRepository;
        }

        public async Task<Exception> RunAsync()
        {
            return await MainJob();
        }

        private async Task<Exception> MainJob()
        {
            try
            {
                logger.LogInformation("Фоновый процесс синхронизациий направлений запущен");
                var x = synchronizeRepository.CreateSynchronizeDepartmentService();
                await x.SynchronizeDepartmentsAsync();

                logger.LogInformation("Фоновый процесс синхронизациий направлений окончен");
                return null;
            }
            catch(Exception e)
            {
                logger.LogInformation($"Фоновый процесс синхронизациий направлений вызвал ошибку: {e.Message}");
                throw;
            }
        }
    }
}

using CVGenerator.Core.Synchronizer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer
{
    public class SynchronizeProjectJob : IBaseSyncService
    {
        private readonly ILogger<SynchronizeProjectJob> logger;
        private readonly ISynchronizeFactory synchronizeRepository;

        public SynchronizeProjectJob(ILogger<SynchronizeProjectJob> logger, ISynchronizeFactory synchronizeRepository)
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
                logger.LogInformation("Фоновый процесс синхронизациий проектов запущен");
                var x = synchronizeRepository.CreateSynchronizeProjectService();
                await x.SynchronizeProjectsAsync();

                logger.LogInformation("Фоновый процесс синхронизациий проектов окончен");
                return null;
            }
            catch (Exception e)
            {
                logger.LogInformation($"Фоновый процесс синхронизациий проектов вызвал ошибку: {e.Message}");
                throw;
            }
        }
    }
}

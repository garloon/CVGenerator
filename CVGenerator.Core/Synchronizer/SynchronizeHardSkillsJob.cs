using CVGenerator.Core.Synchronizer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer
{
    public class SynchronizeHardSkillsJob : IBaseSyncService
    {
        private readonly ILogger<SynchronizeHardSkillsJob> logger;
        private readonly ISynchronizeFactory synchronizeRepository;

        public SynchronizeHardSkillsJob(ILogger<SynchronizeHardSkillsJob> logger, ISynchronizeFactory synchronizeRepository)
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
                logger.LogInformation("Фоновый процесс синхронизациий навыков запущен");
                var x = synchronizeRepository.CreateSynchronizeHardSkillService();
                await x.SynchronizeHardSkillsAsync();

                logger.LogInformation("Фоновый процесс синхронизациий навыков окончен");
                return null;
            }
            catch (Exception e)
            {
                logger.LogInformation($"Фоновый процесс синхронизациий навыков вызвал ошибку: {e.Message}");
                throw;
            }
        }
    }
}

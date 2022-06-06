using CVGenerator.Core.Synchronizer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer
{
    public class SynchronizeCertificatesJob : IBaseSyncService
    {
        private readonly ILogger<SynchronizeCertificatesJob> _logger;
        private readonly ISynchronizeFactory _synchronizeRepository;

        public SynchronizeCertificatesJob(ILogger<SynchronizeCertificatesJob> logger, ISynchronizeFactory synchronizeRepository)
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
                _logger.LogInformation("Фоновый процесс синхронизациий сертификатов запущен");
                var x = _synchronizeRepository.CreateSynchronizeCertificateService();
                await x.SynchronizeCertificatesAsync();

                _logger.LogInformation("Фоновый процесс синхронизациий сертификатов окончен");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Фоновый процесс синхронизациий сертификатов вызвал ошибку: {e.Message}");
                throw;
            }
        }
    }
}

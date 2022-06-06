using CVGenerator.Core.Operations;
using CVGenerator.Core.Operations.Synchronize.Certificates;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices
{
    /// <summary>
    /// Сервис по работе с cинхронизацией сертификатов из ME
    /// </summary>
    public class SynchronizeCertificateService : ISynchronizeCertificateService
    {
        private readonly ILogger _logger;
        private readonly IRequestHelper _requestHelper;
        private readonly ICvOperations _operations;

        public SynchronizeCertificateService(
            IRequestHelper requestHelper,
            ICvOperations operations,
            ILogger logger)
        {
            _requestHelper = requestHelper;
            _operations = operations;
            _logger = logger;
        }

        public async Task SynchronizeCertificatesAsync()
        {
            try
            {
                _logger?.LogInformation("Началась синхронизация данных \"Сертификаты\"");

                var externalCertificates = await _requestHelper.GetCertificatesAsync();

                var requestModel = new CertificatesSynchronizeRequest { ExternalCertificates = externalCertificates };

                var operation = _operations.CreateCertificatesSynchronizeOperation();
                await operation.Execute(requestModel);

                _logger?.LogInformation("Данные по сертификатам синхрониированы");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"При синхронизации данных \"Сертификаты\" возникла ошибка: {ex.Message}");
            }
        }
    }
}

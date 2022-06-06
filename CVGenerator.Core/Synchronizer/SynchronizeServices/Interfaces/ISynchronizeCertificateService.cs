using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces
{
    public interface ISynchronizeCertificateService
    {
        /// <summary>
        /// Синхронизация сертификатов сотрудника из ME
        /// </summary>
        Task SynchronizeCertificatesAsync();
    }
}

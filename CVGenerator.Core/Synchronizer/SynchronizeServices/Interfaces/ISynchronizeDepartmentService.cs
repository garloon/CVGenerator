using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces
{
    public interface ISynchronizeDepartmentService
    {
        /// <summary>
        /// Синхронизация направлений компании сотрудника из ME
        /// </summary>
        Task SynchronizeDepartmentsAsync();
    }
}

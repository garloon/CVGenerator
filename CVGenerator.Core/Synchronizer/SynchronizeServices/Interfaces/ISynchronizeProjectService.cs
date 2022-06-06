using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces
{
    public interface ISynchronizeProjectService
    {
        /// <summary>
        /// Синхронизация проектов из ME
        /// </summary>
        Task SynchronizeProjectsAsync();
    }
}

using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces
{
    public interface ISynchronizeHardSkillService
    {
        /// <summary>
        /// Синхронизация навыков из ME
        /// </summary>
        Task SynchronizeHardSkillsAsync();
    }
}

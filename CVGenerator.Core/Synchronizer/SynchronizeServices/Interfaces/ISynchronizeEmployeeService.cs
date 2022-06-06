using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces
{
    public interface ISynchronizeEmployeeService
    {
        /// <summary>
        /// Синхронизация данных сотрудника
        /// </summary>
        Task SynchronizeEmployeeAsync(long employeeId);

        /// <summary>
        /// Синхронизация данных сотрудников
        /// </summary>
        Task SynchronizeEmployeesAsync();
    }
}

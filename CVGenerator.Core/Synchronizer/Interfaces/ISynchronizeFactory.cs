using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;

namespace CVGenerator.Core.Synchronizer.Interfaces
{
    public interface ISynchronizeFactory
    {
        /// <summary>
        /// Создать сервис синхронизации сертификатов
        /// </summary>
        public ISynchronizeCertificateService CreateSynchronizeCertificateService();

        /// <summary>
        /// Создать сервис синхронизации отделов
        /// </summary>>
        public ISynchronizeDepartmentService CreateSynchronizeDepartmentService();

        /// <summary>
        /// Создать сервис синхронизации пользователей
        /// </summary>
        public ISynchronizeEmployeeService CreateSynchronizeEmployeeService();

        /// <summary>
        /// Создать сервис синхронизации навыков
        /// </summary>
        public ISynchronizeHardSkillService CreateSynchronizeHardSkillService();

        /// <summary>
        /// Создать сервис синхронизации проектов
        /// </summary>
        public ISynchronizeProjectService CreateSynchronizeProjectService();
    }
}

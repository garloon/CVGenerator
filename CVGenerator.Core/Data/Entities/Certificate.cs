using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Сертификат
    /// </summary>
    public class Certificate : EntityBase<long>, IExternal<long?>
    {
        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Наименование сертификата
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сотрудники, владеющие сертификатом
        /// </summary>
        public ICollection<EmployeeCertificate> Employees { get; set; }

        public Certificate()
        {
            Employees = new HashSet<EmployeeCertificate>();
        }
    }
}

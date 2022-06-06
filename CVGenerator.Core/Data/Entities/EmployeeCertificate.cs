namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Сертификаты сотрудника
    /// </summary>
    public class EmployeeCertificate : EntityBase<long>, IExternal<long?>
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор сертификата
        /// </summary>
        public long CertificateId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Сертификат
        /// </summary>
        public virtual Certificate Certificate { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }
    }
}

namespace CVGenerator.Core.Data.Entities.Rules
{
    /// <summary>
    /// Правила заполнения информации об сертификатах
    /// </summary>
    public class CertificateRule : BaseRule
    {
        /// <summary>
        /// Идентификатор сертификата
        /// </summary>
        public long CertificateId { get; set; }

        /// <summary>
        /// Сертификат
        /// </summary>
        public virtual Certificate Certificate { get; set; }

        public bool Equals(CertificateRule сertificateRule)
        {
            return CertificateId == сertificateRule.CertificateId;
        }
    }
}

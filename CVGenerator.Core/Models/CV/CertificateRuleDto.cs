namespace CVGenerator.Core.Models.Cv
{
    /// <summary>
    /// Правила заполнения информации об сертификатах
    /// </summary>
    public class CertificateRuleDto : BaseRuleDto
    {
        /// <summary>
        /// Идентификатор сертификата
        /// </summary>
        public long CertificateId { get; set; }

        public string Name { get; set; }
    }
}
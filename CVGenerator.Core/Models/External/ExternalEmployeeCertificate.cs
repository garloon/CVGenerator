using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalEmployeeCertificate
    {
        /// <summary>
        /// Внешний идентификатор сертификат-сотрудника
        /// </summary>
        [JsonPropertyName("id")]
        public long? ExternalId { get; set; }

        /// <summary>
        /// Внешний идентификатор сертификата
        /// </summary>
        [JsonPropertyName("certId")]
        public long? ExternalCertificateId { get; set; }

        /// <summary>
        /// Наименование сертификата
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
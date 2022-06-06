using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalCertificate
    {
        /// <summary>
        /// Идентификатор сертификата
        /// </summary>
        [JsonPropertyName("id")]
        public long ExternalId { get; set; }

        /// <summary>
        /// Название сертификата
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

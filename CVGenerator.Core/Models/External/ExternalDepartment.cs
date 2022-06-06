using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalDepartment
    {
        /// <summary>
        /// Внешний идентификатор направления
        /// </summary>
        [JsonPropertyName("id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Название направления
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

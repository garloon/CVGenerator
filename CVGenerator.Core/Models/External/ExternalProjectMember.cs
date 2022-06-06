using System;
using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalProjectMember
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [JsonPropertyName("userId")]
        public long ExternalId { get; set; }

        /// <summary>
        /// Дата начала участия в проекте
        /// </summary>
        [JsonPropertyName("startDate")] 
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата выхода из проекта
        /// </summary>
        [JsonPropertyName("endDate")] 
        public DateTime EndDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalProject
    {
        /// <summary>
        /// Идентификатор на внешнем сервисе
        /// </summary>
        [JsonPropertyName("uid")] 
        public string ExternalId { get; set; }

        /// <summary>
        /// Наименование проекта
        /// </summary>
        [JsonPropertyName("name")] 
        public string Name { get; set; }

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Участники проекта
        /// </summary>
        [JsonPropertyName("projectMembers")] 
        public List<ExternalProjectMember> ProjectMembers { get; set; }
    }
}

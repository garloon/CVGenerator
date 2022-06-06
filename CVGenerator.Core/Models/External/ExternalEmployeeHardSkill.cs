using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalHardSkillShortModel
    {
        /// <summary>
        /// Внешний идентификатор скила
        /// </summary>
        [JsonPropertyName("id")]
        public long ExternalId { get; set; }
    }

    public class ExternalEmployeeHardSkill
    {
        /// <summary>
        /// Внешний идентификатор навык-сотрудника
        /// </summary>
        [JsonPropertyName("id")]
        public long ExternalId { get; set; }

        /// <summary>
        /// Навык
        /// </summary>
        [JsonPropertyName("hardSkill")]
        public ExternalHardSkillShortModel HardSkill { get; set; }

        /// <summary>
        /// Внешний идентификатор навыка сотрудника
        /// </summary>
        [JsonPropertyName("value")]
        public string AbilityLevel { get; set; }
    }
}
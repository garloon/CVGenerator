using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalHardSkill
    {
        /// <summary>
        /// Идентификатор скила
        /// </summary>
        [JsonPropertyName("id")]
        public long ExternalId { get; set; }

        /// <summary>
        /// Идентификатор скила родителя
        /// </summary>
        [JsonPropertyName("parentId")]
        public long? ParentId { get; set; }

        /// <summary>
        /// Обозначение скила
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Наименование скила
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Вид скила (Группа скилов или скил)
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Актуальность ли
        /// </summary>
        [JsonPropertyName("isActual")]
        public bool IsActual { get; set; }

        /// <summary>
        /// Уровень вложенности по дереву
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// Использован ли
        /// </summary>
        [JsonPropertyName("isUsed")]
        public bool IsUsed { get; set; }

        /// <summary>
        /// Зависимые скилы
        /// </summary>
        [JsonPropertyName("children")]
        public List<ExternalHardSkill> Childrens { get; set; }
    }
}

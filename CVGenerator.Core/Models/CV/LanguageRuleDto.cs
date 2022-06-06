using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Models.Cv
{
    /// <summary>
    /// Правила заполнения информации об иностранных языках
    /// </summary>
    public class LanguageRuleDto : BaseRuleDto
    {
        /// <summary>
        /// Уровень владения языком
        /// </summary>
        public LanguageLevel LanguageLevel { get; set; }

        /// <summary>
        /// Наименование языка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор иностранного языка
        /// </summary>
        public int LanguageId { get; set; }
    }
}

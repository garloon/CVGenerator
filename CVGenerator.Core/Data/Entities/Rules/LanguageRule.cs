namespace CVGenerator.Core.Data.Entities.Rules
{
    /// <summary>
    /// Правила заполнения информации об иностранных языках
    /// </summary>
    public class LanguageRule : BaseRule
    {
        /// <summary>
        /// Уровень владения языком
        /// </summary>
        public LanguageLevel LanguageLevel { get; set; }

        /// <summary>
        /// Идентификатор иностранного языка
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Иностранный язык
        /// </summary>
        public virtual Language Language { get; set; }

        public bool Equals(LanguageRule languageRule)
        {
            return LanguageLevel == languageRule.LanguageLevel &&
                   LanguageId == languageRule.LanguageId;
        }
    }
}

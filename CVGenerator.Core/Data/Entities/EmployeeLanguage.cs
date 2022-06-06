namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Иностранные языки сотрудника
    /// </summary>
    public class EmployeeLanguage : EntityBase<long>
    {
        /// <summary>
        /// Уровень владения языком
        /// </summary>
        public LanguageLevel LanguageLevel { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Идентификатор иностранного языка
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Иностранный язык
        /// </summary>
        public virtual Language Language { get; set; }
    }
}

namespace CVGenerator.Core.Models.Cv
{
    /// <summary>
    /// Правила заполнения информации о навыках
    /// </summary>
    public class HardSkillRuleDto : BaseRuleDto
    {
        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public long HardSkillId { get; set; }

        public string Title { get; set; }
    }
}
namespace CVGenerator.Core.Data.Entities.Rules
{
    /// <summary>
    /// Правила заполнения информации о навыках
    /// </summary>
    public class HardSkillRule : BaseRule
    {
        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public long HardSkillId { get; set; }

        /// <summary>
        /// Навык
        /// </summary>
        public virtual HardSkill HardSkill { get; set; }

        public bool Equals(HardSkillRule hardSkillRule)
        {
            return HardSkillId == hardSkillRule.HardSkillId;
        }
    }
}

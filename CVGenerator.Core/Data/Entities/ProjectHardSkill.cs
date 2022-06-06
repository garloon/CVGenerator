namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Технологии проекта
    /// </summary>
    public class ProjectHardSkill : EntityBase<long>
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Идентификатор технологии
        /// </summary>
        public long HardSkillId { get; set; }

        /// <summary>
        /// Тенхология
        /// </summary>
        public virtual HardSkill HardSkill { get; set; }

        /// <summary>
        /// Проект
        /// </summary>
        public virtual Project Project { get; set; }
    }
}

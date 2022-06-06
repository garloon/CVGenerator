namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Навыки сотрудника
    /// </summary>
    public class EmployeeHardSkill : EntityBase<long>, IExternal<long?>
    {
        /// <summary>
        /// Уровень владения навыком
        /// </summary>
        public AbilityLevel AbilityLevel { get; set; } = AbilityLevel.Beginner;

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public long HardSkillId { get; set; }

        /// <summary>
        /// Навык
        /// </summary>
        public virtual HardSkill HardSkill { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }
    }
}

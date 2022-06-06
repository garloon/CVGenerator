namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Профессиональные навыки и умения сотрудника =  Competence
    /// </summary>
    public class EmployeeProfessionalAbility : EntityBase<long>
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        public long ProfessionalAbilityId { get; set; }

        public virtual ProfessionalAbility ProfessionalAbility { get; set; }
    }
}

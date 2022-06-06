namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Образование сотрудника
    /// </summary>
    public class EmployeeEducation : EntityBase<long>
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор образования
        /// </summary>
        public long EducationId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public virtual Education Education { get; set; }
    }
}

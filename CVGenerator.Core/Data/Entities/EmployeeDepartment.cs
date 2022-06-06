namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Направления сотрудника
    /// </summary>
    public class EmployeeDepartment : EntityBase<long>
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Идентификатор направления
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Направление
        /// </summary>
        public virtual Department Department { get; set; }
    }
}

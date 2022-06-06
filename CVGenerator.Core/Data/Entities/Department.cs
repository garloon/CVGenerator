using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Направление
    /// </summary>
    public class Department : EntityBase<long>, IExternal<string>
    {
        /// <summary>
        /// Название направления
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внутреннее системное направление
        /// </summary>
        public bool IsApplicationDepartment { get; set; }

        /// <summary>
        /// Выводиться в резюме
        /// </summary>
        public bool IsForCv { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Направление-локация (город)
        /// </summary>
        public bool IsLocation { get; set; }

        /// <summary>
        /// Роль в системе, в которое оценивается направление
        /// </summary>
        public Role Role { get; set; }

        public ICollection<EmployeeDepartment> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<EmployeeDepartment>();
        }
    }
}

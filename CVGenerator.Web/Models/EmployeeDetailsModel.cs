using System.Collections.Generic;

namespace CVGenerator.Web.Models
{
    /// <summary>
    /// Подробные данные сотрудника
    /// </summary>
    public class EmployeeDetailsModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long EmployeeId { get; set; }
        
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email сотрудника
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Направления сотрудника
        /// </summary>
        public List<DepartmentModel> Departments { get; set; }
    }
}

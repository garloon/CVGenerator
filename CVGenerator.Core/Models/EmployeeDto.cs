using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Models
{
    public class EmployeeDto : BaseDto<long>
    {
        public string Login { get; set; }
        
        public Role Role { get; set; }
        
        public string Name { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        public List<DepartmentDto> Departments { get; set; }
    }
}

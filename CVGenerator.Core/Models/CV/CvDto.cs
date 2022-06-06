using System;

namespace CVGenerator.Core.Models.Cv
{
    public class CvDto : BaseDto<Guid>
    {
        /// <summary>
        /// Владелец Cv
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Идентификатор настроек Cv
        /// </summary>
        public long? CvSettingsId { get; set; }

        public CvSettingsDto CvSettings { get; set; }

        /// <summary>
        /// Наименование Cv
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Имя владельца Cv
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Направление сотрудника
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
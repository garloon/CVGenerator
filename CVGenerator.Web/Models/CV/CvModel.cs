using System;

namespace CVGenerator.Web.Models.Cv
{
    public class CvModel
    {
        /// <summary>
        /// Идентификатор Cv
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Владелец Cv
        /// </summary>
        public EmployeeModel Employee { get; set; }

        /// <summary>
        /// Идентификатор настроек Cv
        /// </summary>
        public long? CvSettingsId { get; set; }

        public CvSettingsModel CvSettings { get; set; }

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
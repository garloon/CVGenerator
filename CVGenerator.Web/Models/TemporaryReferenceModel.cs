using System;
using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class TemporaryReferenceModel
    {
        /// <summary>
        /// Идентификатор ссылки
        /// </summary>
        public Guid ReferenceId { get; set; }

        /// <summary>
        /// Идентификатор CV
        /// </summary>
        public Guid CvId { get; set; }

        /// <summary>
        /// Название CV
        /// </summary>
        [Display(Name = "Название CV")]
        public string CvName { get; set; }

        /// <summary>
        /// Таймаут сгорания ссылки.
        /// </summary>
        [Display(Name = "Срок действия ссылки")]
        public DateTime ExpirationTimeout { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Display(Name = "Сотрудник")]
        public string EmployeeName { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System;

namespace CVGenerator.Web.Models
{
    public class EmployeeSearchingModel
    {
        /// <summary>
        /// Идентификатор записи работкника
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Фамилия, имя и отчество работника
        /// </summary>
        [Display(Name = "ФИО")]
        public string FirstLastMiddleName { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        public string Login { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Почта")]
        public string Email { get; set; }

        /// <summary>
        /// Дата деактивации
        /// </summary>
        [Display(Name = "Дата увольнения")]
        public DateTime? Deleted { get; set; }
    }
}

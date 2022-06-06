using System.ComponentModel.DataAnnotations;
using System;

namespace CVGenerator.Web.Models
{
    public class EmployeeProjectModel
    {
        /// <summary>
        /// Идентификатор записи: проект сотрудника
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Display(Name = "Сотрудник")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Название проекта, которое будет видеть клиент
        /// </summary>
        [Required]
        [Display(Name = "Наименование проекта для клиента")]
        public string ShowName { get; set; }

        /// <summary>
        /// Наименование проекта
        /// </summary>
        [Display(Name = "Наименование проекта")]
        public string ProjectName { get; set; }

        /// <summary>
        /// Наименование роли на проекте
        /// </summary>
        [Display(Name = "Роль на проекте")]
        public string RoleName { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        [Display(Name = "Описание проекта")]
        public string DescriptionProject { get; set; }

        /// <summary>
        /// Сторонний проект
        /// </summary>
        [Display(Name = "Персональный проект")]
        public bool IsPersonalProject { get; set; }

        /// <summary>
        /// Описание задач, которые сотрудник выполнял на проекте 
        /// </summary>
        [Required]
        [Display(Name = "Задачи на проекте")]
        public string MyTasks { get; set; }

        /// <summary>
        /// Дата начала работы на проекте
        /// </summary>
        [Required]
        [Display(Name = "Дата начала работы на проекте")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата окончания работы на проекте
        /// </summary>        
        [Required]
        [Display(Name = "Дата окончания работы на проекте")]
        public DateTime? EndDate { get; set; }
    }
}
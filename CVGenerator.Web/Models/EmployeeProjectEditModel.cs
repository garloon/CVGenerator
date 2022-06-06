using System;
using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class EmployeeProjectEditModel
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Модель с данными проекта
        /// </summary>
        [Required]
        public ProjectDetailsModel Project { get; set; }

        /// <summary>
        /// Роль сотрудника на проекте
        /// </summary>
        [Required]
        [Display(Name = "Роль сотрудника на проекте")]
        public ProjectRoleModel ProjectRole { get; set; }

        /// <summary>
        /// Название проекта, которое будет видеть клиент
        /// </summary>
        [Required]
        [Display(Name = "Наименование проекта для клиента")]
        public string ShowName { get; set; }

        /// <summary>
        /// Описание задач, которые сотрудник выполнял на проекте 
        /// </summary>
        [Required]
        [Display(Name = "Задачи на проекте")]
        public string MyTasks { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        [Required]
        [Display(Name = "Описание проекта")]
        public string DescriptionProject { get; set; }

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

        /// <summary>
        /// Адрес для перенаправления после сохранения
        /// </summary>
        public string RefererUrl { get; set; } = string.Empty;

        public EmployeeProjectEditModel()
        {
            Project = new ProjectDetailsModel();
            ProjectRole = new ProjectRoleModel();
        }
    }
}

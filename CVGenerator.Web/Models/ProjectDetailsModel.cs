using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Web.Models
{
    public class ProjectDetailsModel
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Наименование проекта
        /// </summary>
        [Required]
        [Display(Name = "Наименование проекта")]
        public string Name { get; set; }

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        [Display(Name = "Дата начала проекта")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>        
        [Display(Name = "Дата окончания проекта")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Актуальный ли проект на данный момент
        /// </summary>
        [Display(Name = "Актуальный проект")]
        public bool IsActual { get; set; }

        /// <summary>
        /// Личный проект пользователя?
        /// </summary>
        [Required]
        public bool IsPersonal { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public ICollection<EmployeeProject> Employees { get; set; }

        /// <summary>
        /// Навыки проекта
        /// </summary>
        public ICollection<ProjectHardSkill> Skills { get; set; }
    }
}

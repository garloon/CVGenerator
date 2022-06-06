using System.ComponentModel.DataAnnotations;
using System;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Web.Models
{
    /// <summary>
    /// Информация об образовании сотрудника
    /// </summary>
    public class EmployeeEducationModel
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Required]
        public long EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор записи с образованием сотрудника
        /// </summary>
        public long? EmployeeEducationId { get; set; }

        /// <summary>
        /// Название учебного заведения
        /// </summary>
        [Required]
        [Display(Name = "Университет")]
        public string UniversityName { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [Required]
        [Display(Name = "Специальность")]
        public string SpecialtyName { get; set; }

        /// <summary>
        /// Тип специальности
        /// </summary>
        [Required]
        [Display(Name = "Тип специальности")]
        public TypeSpecialty TypeSpecialty { get; set; }

        /// <summary>
        /// Год начала обучения
        /// </summary>
        [Display(Name = "Начало обучения")]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// Год окончания обучения
        /// </summary>        
        [Display(Name = "Конец обучения")]
        public DateTime? FinishDate { get; set; }
    }
}

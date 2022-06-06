using System.ComponentModel.DataAnnotations;
using System;

using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Web.Models
{
    public class EducationModel
    {
        /// <summary>
        /// Идентификатор записи об обучении
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Название учебного заведения
        /// </summary>
        [Required]
        [Display(Name = "Учебное заведение")]
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
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// Год окончания обучения
        /// </summary>
        [Display(Name = "Окончание обучения")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Дата обновления записи
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Дата деактивации записи
        /// </summary>
        public DateTime? Deleted { get; set; }
    }
}

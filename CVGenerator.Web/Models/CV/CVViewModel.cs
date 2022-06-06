using System;
using System.ComponentModel.DataAnnotations;
using CVGenerator.Web.Models.CV;

namespace CVGenerator.Web.Models.Cv
{
    /// <summary>
    /// Модeль для отображения Cv
    /// </summary>
    public class CvViewModel
    {
        /// <summary>
        /// Идентификатор Cv
        /// </summary>
        public Guid CvId { get; set; }

        /// <summary>
        /// Название резюме
        /// </summary>
        [Display(Name= "Название резюме")]
        public string Title { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [Display(Name = "Дата создания")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Комментарий к записи
        /// </summary>
        [Display(Name = "Комментарий к записи")]
        public string Description { get; set; }

        /// <summary>
        /// Статус резюме
        /// </summary>
        [Display(Name = "Статус резюме")]
        public CvStatus Status { get; set; }
    }
}

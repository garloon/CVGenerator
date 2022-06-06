using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class DepartmentModel
    {
        /// <summary>
        /// Идентификатор направления
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Название направления
        /// </summary>
        [Required]
        [Display(Name = "Название направления")]
        public string Name { get; set; }

        /// <summary>
        /// Роль в системе, в которое оценивается направление
        /// </summary>
        [Display(Name = "Роль сотрудников направления")]
        public int DepartmentRole { get; set; }

        /// <summary>
        /// Направление-локация (город)
        /// </summary>
        [Display(Name = "Локация")]
        public bool IsLocation { get; set; }

        /// <summary>
        /// Использовать в CV
        /// </summary>
        [Display(Name = "Использовать в CV")]
        public bool IsForCv { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class ProjectModel
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
        /// Актуальный ли проект на данный момент
        /// </summary>
        [Display(Name = "Актуальный проект")]
        public bool IsActual { get; set; }

        /// <summary>
        /// Личный проект пользователя?
        /// </summary>
        [Display(Name="Пользовательский проект")]
        public bool IsPersonal { get; set; }
    }
}

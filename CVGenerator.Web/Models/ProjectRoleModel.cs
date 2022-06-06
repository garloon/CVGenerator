using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class ProjectRoleModel
    {
        /// <summary>
        /// Идентификатор роли на проекте
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Короткое название (абривиатура)
        /// </summary>
        [Required]
        [Display(Name = "Роль")]
        [StringLength(15)]
        public string ShortName { get; set; }

        /// <summary>
        /// Наименование роли на проекте
        /// </summary>
        [Required]
        [Display(Name = "Описание роли")]
        public string Name { get; set; }

        /// <summary>
        /// Наименование роли от пользователя?
        /// </summary>
        [Display(Name = "Пользовательская роль")]
        public bool IsPersonal { get; set; }
    }
}

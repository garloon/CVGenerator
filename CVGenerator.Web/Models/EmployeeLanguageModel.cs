using CVGenerator.Core.Data.Entities;
using System.ComponentModel.DataAnnotations;


namespace CVGenerator.Web.Models
{
    /// <summary>
    /// Данные сотрудника о владении ин. языком
    /// </summary>
    public class EmployeeLanguageModel
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Required]
        public long EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор ин. языка
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Ин. язык
        /// </summary>
        [Display(Name="Иностранный язык")]
        public string Language { get; set; }

        /// <summary>
        /// Уровень владения ин. языком
        /// </summary>
        [Display(Name = "Уровень")]
        public LanguageLevel Level { get; set; }

        /// <summary>
        /// Уровень владения ин. языком
        /// </summary>
        public string LevelName { get; set; }
    }
}

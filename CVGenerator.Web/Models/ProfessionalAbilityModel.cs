using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    /// <summary>
    /// Профессиональные навыки и умения
    /// </summary>
    public class ProfessionalAbilityModel
    {
        public long? Id { get; set; }
        
        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    /// <summary>
    /// Данные сотрудника о проф. навыках и умениях
    /// </summary>
    public class EmployeeAbilityModel
    {
        public long EmployeeId { get; set; }

        public long? EmployeeAbilityId { get; set; }

        [Display(Name = "Описание")]
        public string Name { get; set; }

        public long PositionId { get; set; }

        public bool Required { get; set; }
    }
}

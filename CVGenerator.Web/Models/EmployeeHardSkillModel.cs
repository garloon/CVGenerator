using CVGenerator.Core.Data.Entities;
using System.ComponentModel.DataAnnotations;


namespace CVGenerator.Web.Models
{
    public class EmployeeHardSkillModel
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Required]
        public long EmployeeId { get; set; }

        public string Title { get; set; }

        public AbilityLevel AbilityLevel { get; set; }
    }
}
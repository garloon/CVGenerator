using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Уровень владения навыком
    /// </summary>
    public enum AbilityLevel
    {
        [Display(Name = "Знаком")]
        Beginner = 1,
        [Display(Name = "Есть опыт")]
        Skilled = 2,
        [Display(Name = "Эксперт")]
        Expert = 3
    }
}

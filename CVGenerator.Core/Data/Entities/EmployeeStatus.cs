using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Статус сотрудника
    /// </summary>
    public enum EmployeeStatus
    {
        [Display(Name = "Действующий")]
        ACTIVE = 1,

        [Display(Name = "Уволенный")]
        INACTIVE
    }
}

using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Core.Data.Entities
{
    public enum TypeSpecialty
    {
        [Display(Name = "Техническая специальность")]
        Technical = 1,

        [Display(Name = "Гуманитарная специальность")]
        Humanitarian = 2
    }
}

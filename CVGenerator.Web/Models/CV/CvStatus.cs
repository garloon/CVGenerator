using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models.CV
{
    public enum CvStatus
    {
        [Display(Name = "Акульный вариант")]
        Active,
        [Display(Name = "Архивная запись")]
        Archive
    }
}

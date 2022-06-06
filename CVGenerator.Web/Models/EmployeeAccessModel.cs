using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    public class EmployeeAccessModel
    {
        public long EmployeeId { get; set; }

        [Display(Name="Имя сотрудника")]
        public string EmployeeName { get; set; }

        [Display(Name = "Администратор")]
        public bool IsAdministrator { get; set; }

        [Display(Name = "Супервайзер")]
        public bool IsSupervisor { get; set; }

        [Display(Name = "Аккаунт")]
        public bool IsAccount { get; set; }

    }
}

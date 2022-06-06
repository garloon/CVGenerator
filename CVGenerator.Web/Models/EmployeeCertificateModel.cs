using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models
{
    /// <summary>
    /// Данные сотрудника о сертификате
    /// </summary>
    public class EmployeeCertificateModel
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор связи сотрудника с сертификатом
        /// </summary>
        public long? EmployeeCertificateId { get; set; }

        [Required]
        [Display(Name = "Наименование сертификата")]
        public string Name { get; set; }
    }
}

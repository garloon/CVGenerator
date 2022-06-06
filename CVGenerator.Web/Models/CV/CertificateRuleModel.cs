using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Web.Models.Cv
{
    public class CertificateRuleModel : BaseRuleModal
    {
        /// <summary>
        /// Идентификатор сертификата
        /// </summary>
        public long? CertificateId { get; set; }

        [Display(Name = "Наименование сертификата")]
        public string Name { get; set; }
    }
}

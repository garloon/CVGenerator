

using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Web.Models.Cv
{
    public class EducationRuleModel : BaseRuleModal
    {
        /// <summary>
        /// Название учебного заведения
        /// </summary>
        public string UniversityName { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        public string SpecialtyName { get; set; }

        /// <summary>
        /// Тип специальности
        /// </summary>
        public TypeSpecialty TypeSpecialty { get; set; }
    }
}

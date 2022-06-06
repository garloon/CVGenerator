using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Models.Cv
{
    public class EducationRuleDto : BaseRuleDto
    {
        /// <summary>
        /// Идентификатор образования
        /// </summary>
        public long EducationId { get; set; }

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
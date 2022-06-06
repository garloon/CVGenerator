using System.Collections.Generic;

namespace CVGenerator.Core.Models.Cv
{
    /// <summary>
    /// Настройки Cv
    /// </summary>
    public class CvSettingsDto : BaseDto<long?>
    {
        /// <summary>
        /// Правила заполнения информации об иностранных языках
        /// </summary>
        public List<LanguageRuleDto> LanguageRules { get; set; }

        /// <summary>
        /// Правила заполнения информации об образовании
        /// </summary>
        public List<EducationRuleDto> EducationRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о проектах
        /// </summary>
        public List<ProjectRuleDto> ProjectRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о профессиональных навыков и умений
        /// </summary>
        public List<ProfessionalAbilityRuleDto> ProfessionalAbilityRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о навыках
        /// </summary>
        public List<HardSkillRuleDto> HardSkillRules { get; set; }

        /// <summary>
        /// Правила заполнения информации об сертификатах
        /// </summary>
        public List<CertificateRuleDto> CertificateRules { get; set; }
    }
}
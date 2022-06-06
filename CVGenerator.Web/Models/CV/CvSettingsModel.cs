using System.Collections.Generic;

namespace CVGenerator.Web.Models.Cv
{
    public class CvSettingsModel
    {
        /// <summary>
        /// Идентификатор настроек Cv
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Правила заполнения информации об иностранных языках
        /// </summary>
        public List<LanguageRuleModel> LanguageRules { get; set; }

        /// <summary>
        /// Правила заполнения информации об образовании
        /// </summary>
        public List<EducationRuleModel> EducationRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о проектах
        /// </summary>
        public List<ProjectRuleModel> ProjectRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о профессиональных навыков и умений
        /// </summary>
        public List<ProfessionalAbilityRuleModel> ProfessionalAbilityRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о навыках
        /// </summary>
        public List<HardSkillRuleModel> HardSkillRules { get; set; }

        /// <summary>
        /// Правила заполнения информации об сертификатах
        /// </summary>
        public List<CertificateRuleModel> CertificateRules { get; set; }
    }
}

using CVGenerator.Core.Data.Entities.Rules;
using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Настройки Cv
    /// </summary>
    public class CvSettings : EntityBase<long>
    {
        public Cv Cv { get; set; }

        /// <summary>
        /// Правила заполнения информации об иностранных языках
        /// </summary>
        public virtual ICollection<LanguageRule> LanguageRules { get; set; }

        /// <summary>
        /// Правила заполнения информации об образовании
        /// </summary>
        public virtual ICollection<EducationRule> EducationRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о проектах
        /// </summary>
        public virtual ICollection<ProjectRule> ProjectRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о профессиональных навыков и умений
        /// </summary>
        public virtual ICollection<ProfessionalAbilityRule> ProfessionalAbilityRules { get; set; }

        /// <summary>
        /// Правила заполнения информации о навыках
        /// </summary>
        public virtual ICollection<HardSkillRule> HardSkillRules { get; set; }

        /// <summary>
        /// Правила заполнения информации об сертификатах
        /// </summary>
        public virtual ICollection<CertificateRule> CertificateRules { get; set; }

        public CvSettings()
        {
            ProjectRules = new HashSet<ProjectRule>();
            LanguageRules = new HashSet<LanguageRule>();
            HardSkillRules = new HashSet<HardSkillRule>();
            EducationRules = new HashSet<EducationRule>();
            CertificateRules = new HashSet<CertificateRule>();
            ProfessionalAbilityRules = new HashSet<ProfessionalAbilityRule>();
        }
    }
}

using CVGenerator.Core.Repositories.Interfaces;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core
{
    public interface IGeneratorRepository
    {
        ICvRepository Cv { get; }
        IProjectRepository Project { get; }
        IEmployeeRepository Employee { get; }
        ILanguageRepository Language { get; }
        IEducationRepository Education { get; }
        IHardSkillRepository HardSkill { get; }
        ICvSettingsRepository CvSettings { get; }
        ICertificateRepository Certificate { get; }
        IDepartmentRepository Department { get; }
        IProjectRoleRepository ProjectRole { get; }
        IProjectHardSkillRepository ProjectHardSkill { get; }
        IEmployeeProjectRepository EmployeeProject { get; }
        IEmployeeHardSkillRepository EmployeeHardSkill { get; }
        IEmployeeProfessionalAbilityRepository EmployeeAbility { get; }
        IEmployeeLanguageRepository EmployeeLanguage { get; }
        IEmployeeEducationRepository EmployeeEducation { get; }
        IEmployeeCertificateRepository EmployeeCertificate { get; }
        IEmployeeDepartmentRepository EmployeeDepartment { get; }
        ITemporaryReferenceRepository TemporaryReference { get; }
        IProfessionalAbilityRepository ProfessionalAbility { get; }

        IProjectRuleRepository ProjectRule { get; }
        ILanguageRuleRepository LanguageRule { get; }
        IEducationRuleRepository EducationRule { get; }
        IHardSkillRuleRepository HardSkillRule { get; }
        ICertificateRuleRepository CertificateRule { get; }
        IProfessionalAbilityRuleRepository ProfessionalAbilityRule { get; }
    }
}

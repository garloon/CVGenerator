using CVGenerator.Core.Repositories.Interfaces;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core
{
    public class GeneratorRepository : IGeneratorRepository
    {
        public GeneratorRepository(
            GeneratorContext generatorContext,
            IProfessionalAbilityRuleRepository professionalAbilityRuleRepository,
            ICvRepository cvRepository,
            ICvSettingsRepository cvSettingsRepository,
            ICertificateRepository certificateRepository,
            IDepartmentRepository departmentRepository,
            IEducationRepository educationRepository,
            IEducationRuleRepository educationRuleRepository,
            IEmployeeProfessionalAbilityRepository employeeAbilityRepository,
            IEmployeeDepartmentRepository employeeDepartmentRepository,
            IEmployeeEducationRepository employeeEducationRepository,
            IEmployeeLanguageRepository employeeLanguageRepository,
            IEmployeeProjectRepository employeeProjectRepository,
            IEmployeeHardSkillRepository employeeHardSkillRepository,
            IEmployeeCertificateRepository employeeCertificate,
            IEmployeeRepository employeeRepository,
            ILanguageRepository languageRepository,
            ILanguageRuleRepository languageRuleRepository,
            IProfessionalAbilityRepository professionalAbilityRepository,
            IHardSkillRepository hardSkillRepository,
            IProjectRepository projectRepository,
            IProjectRoleRepository projectRoleRepository,
            IProjectHardSkillRepository projectHardSkillRepository,
            IHardSkillRuleRepository hardSkillRuleRepository,
            ICertificateRuleRepository certificateRuleRepository,
            IProjectRuleRepository projectRuleRepository,
            ITemporaryReferenceRepository temporaryReference)
        {
            Context = generatorContext;
            Cv = cvRepository;
            CvSettings = cvSettingsRepository;
            Certificate = certificateRepository;
            Department = departmentRepository;
            Education = educationRepository;
            EmployeeAbility = employeeAbilityRepository;
            EmployeeDepartment = employeeDepartmentRepository;
            EmployeeEducation = employeeEducationRepository;
            EmployeeLanguage = employeeLanguageRepository;
            EmployeeProject = employeeProjectRepository;
            EmployeeHardSkill = employeeHardSkillRepository;
            EmployeeCertificate = employeeCertificate;
            Employee = employeeRepository;
            Language = languageRepository;
            ProfessionalAbility = professionalAbilityRepository;
            HardSkill = hardSkillRepository;
            Project = projectRepository;
            ProjectRole = projectRoleRepository;
            ProjectHardSkill = projectHardSkillRepository;
            TemporaryReference = temporaryReference;

            ProjectRule = projectRuleRepository;
            LanguageRule = languageRuleRepository;
            EducationRule = educationRuleRepository;
            HardSkillRule = hardSkillRuleRepository;
            CertificateRule = certificateRuleRepository;
            ProfessionalAbilityRule = professionalAbilityRuleRepository;
        }

        public GeneratorContext Context { get; }

        public ICvRepository Cv { get; }
        public IProjectRepository Project { get; }
        public IEmployeeRepository Employee { get; }
        public ILanguageRepository Language { get; }
        public IEducationRepository Education { get; }
        public IHardSkillRepository HardSkill { get; }
        public ICvSettingsRepository CvSettings { get; }
        public ICertificateRepository Certificate { get; }
        public IDepartmentRepository Department { get; }
        public IProjectRoleRepository ProjectRole { get; }
        public IProjectHardSkillRepository ProjectHardSkill { get; }
        public IEmployeeProjectRepository EmployeeProject { get; }
        public IEmployeeProfessionalAbilityRepository EmployeeAbility { get; }
        public IEmployeeLanguageRepository EmployeeLanguage { get; }
        public IEmployeeEducationRepository EmployeeEducation { get; }
        public IEmployeeDepartmentRepository EmployeeDepartment { get; }
        public IEmployeeHardSkillRepository EmployeeHardSkill { get; }
        public IEmployeeCertificateRepository EmployeeCertificate { get;  }
        public ITemporaryReferenceRepository TemporaryReference { get; }
        public IProfessionalAbilityRepository ProfessionalAbility { get; }

        public IProjectRuleRepository ProjectRule { get; }
        public ILanguageRuleRepository LanguageRule { get; }
        public IEducationRuleRepository EducationRule { get; }
        public IHardSkillRuleRepository HardSkillRule { get; }
        public ICertificateRuleRepository CertificateRule { get; }
        public IProfessionalAbilityRuleRepository ProfessionalAbilityRule { get; }
    }
}


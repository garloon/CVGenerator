using ProfessionalAbilityRule = CVGenerator.Core.Data.Entities.Rules.ProfessionalAbilityRule;
using System.Collections.Generic;
using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Models.Cv;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Operations.Cv.Generate
{
    public class CvRulesBuilder
    {
        private readonly IGeneratorRepository _repository;

        public CvRulesBuilder(IGeneratorRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateEducationRules(long cvSettingsId, ICollection<EmployeeEducation> educations)
        {
            foreach (var education in educations)
            {
                await _repository.EducationRule.AddAsync(new EducationRule
                {
                    EducationId = education.EducationId,
                    CvSettingsId = cvSettingsId
                });
            }
        }

        public async Task CreateLanguageRules(long cvSettingsId, ICollection<EmployeeLanguage> languages)
        {
            foreach (var language in languages)
            {
                await _repository.LanguageRule.AddAsync(new LanguageRule
                {
                    LanguageLevel = language.LanguageLevel,
                    LanguageId = language.LanguageId,
                    CvSettingsId = cvSettingsId
                });
            }
        }

        public async Task CreateProfessionalAbilityRules(long cvSettingsId, ICollection<EmployeeProfessionalAbility> professionalAbilities)
        {
            foreach (var professionalAbility in professionalAbilities)
            {
                await _repository.ProfessionalAbilityRule.AddAsync(new ProfessionalAbilityRule
                {
                    Name = professionalAbility.ProfessionalAbility.Name,
                    CvSettingsId = cvSettingsId
                });
            }
        }

        public async Task CreateHardSkillRules(long cvSettingsId, ICollection<EmployeeHardSkill> hardSkills)
        {
            foreach (var hardSkill in hardSkills)
            {
                await _repository.HardSkillRule.AddAsync(new HardSkillRule
                {
                    HardSkillId = hardSkill.HardSkillId,
                    CvSettingsId = cvSettingsId
                });
            }
        }

        public async Task CreateProjectRules(long cvSettingsId, ICollection<EmployeeProject> projects)
        {
            foreach (var project in projects)
            {
                await _repository.ProjectRule.AddAsync(new ProjectRule
                {
                    ShowName = project.ShowName,
                    MyTasks = project.MyTasks,
                    StartDate = project.StartDate,
                    DescriptionProject = project.DescriptionProject,
                    EndDate = project.EndDate,
                    ProjectRoleId = project.ProjectRoleId.Value,
                    CvSettingsId = cvSettingsId
                });
            }
        }
        public async Task CreateCertificateRules(long cvSettingsId, ICollection<EmployeeCertificate> certificates)
        {
            foreach (var certificate in certificates)
            {
                await _repository.CertificateRule.AddAsync(new CertificateRule
                {
                    CertificateId = certificate.CertificateId,
                    CvSettingsId = cvSettingsId
                });
            }
        }

        public async Task CreateCertificateRules(long cvSettingsId, ICollection<CertificateRuleDto> certificateRules)
        {
            var certificates = certificateRules
                .Select(c => new EmployeeCertificate { CertificateId = c.CertificateId })
                .ToList();

            await CreateCertificateRules(cvSettingsId, certificates);
        }

        public async Task CreateProjectRules(long cvSettingsId, ICollection<ProjectRuleDto> projectRules)
        {
            var projects = projectRules
                .Select(c => new EmployeeProject
                {
                    ShowName = c.ShowName,
                    MyTasks = c.MyTasks,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ProjectRoleId = c.ProjectRoleId
                })
                .ToList();

            await CreateProjectRules(cvSettingsId, projects);
        }

        public async Task CreateHardSkillRules(long cvSettingsId, ICollection<HardSkillRuleDto> hardSkillRules)
        {
            var hardSkills = hardSkillRules
                .Select(c => new EmployeeHardSkill { HardSkillId = c.HardSkillId })
                .ToList();

            await CreateHardSkillRules(cvSettingsId, hardSkills);
        }

        public async Task CreateProfessionalAbilityRules(long cvSettingsId, ICollection<ProfessionalAbilityRuleDto> professionalAbilityRules)
        {
            var professionalAbilities = professionalAbilityRules
                .Select(c => new EmployeeProfessionalAbility
                {
                    ProfessionalAbility = new ProfessionalAbility { Name = c.Name } 
                })
                .ToList();

            await CreateProfessionalAbilityRules(cvSettingsId, professionalAbilities);
        }

        public async Task CreateLanguageRules(long cvSettingsId, ICollection<LanguageRuleDto> languageRules)
        {
            var languages = languageRules
                .Select(c => new EmployeeLanguage
                {
                    LanguageId = c.LanguageId,
                    LanguageLevel = c.LanguageLevel
                })
                .ToList();

            await CreateLanguageRules(cvSettingsId, languages);
        }

        public async Task CreateEducationRules(long cvSettingsId, ICollection<EducationRuleDto> educationRules)
        {
            var educations = educationRules
                .Select(c => new EmployeeEducation { EducationId = c.EducationId })
                .ToList();

            await CreateEducationRules(cvSettingsId, educations);
        }
    }
}
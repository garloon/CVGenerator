using AutoMapper;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Web.Models;
using CVGenerator.Web.Models.Cv;
using CVGenerator.Web.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVGenerator.Web.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cv, CvViewModel>()
                .ForMember(dest => dest.Status, opt =>
                        opt.MapFrom(dest => dest.Deleted != null ? CvStatus.Archive : CvStatus.Active))
                .ForMember(dest => dest.CvId, opt =>
                    opt.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Title, opt =>
                    opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(dest => dest.Description))
                .ReverseMap();

            CreateMap<Cv, CvModel>()
                .ForMember(ed => ed.EmployeeName, opt =>
                    opt.MapFrom(model => model.Employee.FirstName))
                .ForMember(cv => cv.CvSettings, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CvSettings, CvSettingsModel>();

            CreateMap<ProjectRule, ProjectRuleModel>();

            CreateMap<ProfessionalAbilityRule, ProfessionalAbilityRuleModel>();

            CreateMap<CertificateRule, CertificateRuleModel>()
                .ForMember(ed => ed.Name, opt => opt.MapFrom(model => model.Certificate.Name));

            CreateMap<EducationRule, EducationRuleModel>()
                .ForMember(ed => ed.SpecialtyName, opt => opt.MapFrom(model => model.Education.SpecialtyName))
                .ForMember(ed => ed.TypeSpecialty, opt => opt.MapFrom(model => model.Education.TypeSpecialty))
                .ForMember(ed => ed.UniversityName, opt => opt.MapFrom(model => model.Education.UniversityName));

            CreateMap<LanguageRule, LanguageRuleModel>()
                .ForMember(ed => ed.Name, opt => opt.MapFrom(model => model.Language.Name));


            CreateMap<HardSkillRule, HardSkillRuleModel>()
                .ForMember(ed => ed.Title, opt => opt.MapFrom(model => model.HardSkill.Title));

            CreateMap<Employee, EmployeeModel>();

            CreateMap<ProfessionalAbility, ProfessionalAbilityModel>().ReverseMap();

            CreateMap<Education, EducationModel>().ReverseMap();

            CreateMap<Employee, EmployeeSearchingModel>()
                .ForMember(empl => empl.FirstLastMiddleName, opt =>
                    opt.MapFrom(model => string.Join(' ', model.LastName, model.FirstName, model.MiddleName)));

            CreateMap<Employee, EmployeeDetailsModel>()
                .ForMember(empl => empl.Name, opt =>
                    opt.MapFrom(model => string.Join(' ', model.FirstName, model.LastName)))
                .ForMember(empl => empl.EmployeeId, opt =>
                    opt.MapFrom(model => model.Id))
                .ForMember(empl => empl.Email, opt =>
                    opt.MapFrom(model => model.Email))
                .ForMember(empl => empl.Departments, opt =>
                    opt.MapFrom(model => model.Departments.Select(c => c.Department).Where(dep => !dep.IsApplicationDepartment)));

            CreateMap<Department, DepartmentModel>()
                .ForMember(dep => dep.DepartmentRole, opt =>
                    opt.MapFrom(src => (int)src.Role))
                .ReverseMap();

            CreateMap<Department, DepartmentSelect>().ReverseMap();

            CreateMap<EmployeeLanguage, EmployeeLanguageModel>()
                .ForMember(dest => dest.Language, opt =>
                    opt.MapFrom(src => src.Language != null ? src.Language.Name : string.Empty))
                .ForMember(dest => dest.LevelName, opt =>
                    opt.MapFrom(src => src.LanguageLevel.ToString()));

            CreateMap<EmployeeEducation, EmployeeEducationModel>()
                .ForMember(dest => dest.EmployeeEducationId, opt =>
                    opt.MapFrom(src => src.EducationId))
                .ForMember(dest => dest.UniversityName, opt =>
                    opt.MapFrom(src => src.Education.UniversityName))
                .ForMember(dest => dest.TypeSpecialty, opt =>
                    opt.MapFrom(src => src.Education.TypeSpecialty))
                .ForMember(dest => dest.SpecialtyName, opt =>
                    opt.MapFrom(src => src.Education.SpecialtyName))
                .ForMember(dest => dest.BeginDate, opt =>
                    opt.MapFrom(src => src.Education.BeginDate))
                .ForMember(dest => dest.FinishDate, opt =>
                    opt.MapFrom(src => src.Education.FinishDate));

            CreateMap<EmployeeProfessionalAbility, EmployeeAbilityModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.EmployeeAbilityId, opt => opt.MapFrom(src => src.ProfessionalAbilityId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProfessionalAbility.Name))
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.ProfessionalAbility.PositionId))
                .ForMember(dest => dest.Required, opt => opt.MapFrom(src => src.ProfessionalAbility.Required));

            CreateMap<EmployeeHardSkill, EmployeeHardSkillModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.HardSkill.Title));

            CreateMap<EmployeeCertificate, EmployeeCertificateModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.EmployeeCertificateId, opt => opt.MapFrom(src => src.CertificateId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Certificate.Name));

            CreateMap<Employee, EmployeeAccessModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => string.Join(' ', src.LastName, src.FirstName, src.MiddleName ?? string.Empty)))
                .ForMember(dest => dest.IsAdministrator, opt => opt.Ignore())
                .ForMember(dest => dest.IsSupervisor, opt => opt.Ignore())
                .ForMember(dest => dest.IsAccount, opt => opt.Ignore());

            CreateMap<Project, ProjectDetailsModel>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<ProjectRole, ProjectRoleModel>().ReverseMap();

            CreateMap<EmployeeProject, EmployeeProjectEditModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id > 0 ? src.Id : null as long?))
                .ForMember(dest => dest.EmployeeName,
                    opt => opt.MapFrom(src => src.Employee != null ? string.Join(' ', src.Employee.FirstName, src.Employee.LastName) : string.Empty))
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate > DateTime.MinValue ? src.StartDate : null as DateTime?))
                .ForMember(dest => dest.EndDate,
                    opt => opt.MapFrom(src => src.EndDate > DateTime.MinValue ? src.EndDate : null as DateTime?));

            CreateMap<EmployeeProject, EmployeeProjectModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName,
                    opt => opt.MapFrom(src => src.Employee != null ? string.Join(' ', src.Employee.FirstName, src.Employee.LastName) : string.Empty))
                .ForMember(dest => dest.ProjectName,
                    opt => opt.MapFrom(src => src.Project != null ? src.Project.Name : string.Empty))
                .ForMember(dest => dest.IsPersonalProject,
                    opt => opt.MapFrom(src => src.Project != null && src.Project.IsPersonal))
                .ForMember(dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.ProjectRole != null ? src.ProjectRole.Name : string.Empty));

            CreateMap<TemporaryReference, TemporaryReferenceModel>()
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CvId, opt => opt.MapFrom(src => src.CvId))
                .ForMember(dest => dest.CvName, opt => opt.MapFrom(src => src.Cv != null ? src.Cv.Name : string.Empty))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Cv != null ? src.Cv.EmployeeId : 0))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src =>
                    src.Cv != null && src.Cv.Employee != null ?
                    string.Join(' ', src.Cv.Employee.FirstName, src.Cv.Employee.LastName) :
                    string.Empty));
        }
    }
}

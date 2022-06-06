using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Models.Cv;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Models;
using AutoMapper;

namespace CVGenerator.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectRole, ProjectRoleDto>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(emp => emp.Name, opt => opt.MapFrom(model => string.Join(' ', model.FirstName, model.LastName)))
                .ForMember(emp => emp.Departments, opt => opt.Ignore())
                .ForMember(emp => emp.Role, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Cv, CvDto>()
                .ForMember(ed => ed.EmployeeName, opt => opt.MapFrom(model => model.Employee.FirstName))
                .ForMember(cv => cv.CvSettings, opt => opt.Ignore());

            CreateMap<CvSettings, CvSettingsDto>();

            CreateMap<ProjectRule, ProjectRuleDto>();

            CreateMap<ProfessionalAbilityRule, ProfessionalAbilityRuleDto>();

            CreateMap<CertificateRule, CertificateRuleDto>()
                .ForMember(ed => ed.Name, opt => opt.MapFrom(model => model.Certificate.Name));

            CreateMap<EducationRule, EducationRuleDto>()
                .ForMember(ed => ed.SpecialtyName, opt => opt.MapFrom(model => model.Education.SpecialtyName))
                .ForMember(ed => ed.TypeSpecialty, opt => opt.MapFrom(model => model.Education.TypeSpecialty))
                .ForMember(ed => ed.UniversityName, opt => opt.MapFrom(model => model.Education.UniversityName));

            CreateMap<LanguageRule, LanguageRuleDto>()
                .ForMember(ed => ed.Name, opt => opt.MapFrom(model => model.Language.Name));

            CreateMap<HardSkillRule, HardSkillRuleDto>()
                .ForMember(ed => ed.Title, opt => opt.MapFrom(model => model.HardSkill.Title));
        }
    }
}
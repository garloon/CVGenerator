using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Data.Entities.Rules;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="CvSettings"/>
    /// </summary>
    public class CvSettingsFilter : BaseFilterModel<CvSettings, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public CvSettingsFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public CvSettingsFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public CvSettingsFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="HardSkillRule"/>
        /// </summary>
        public bool IncludeHardSkillRules { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="ProjectRule"/>
        /// </summary>
        public bool IncludeProjectRules { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="ProfessionalAbilityRule"/>
        /// </summary>
        public bool IncludeProfessionalAbilityRules { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="EducationRule"/>
        /// </summary>
        public bool IncludeEducationRules { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="LanguageRule"/>
        /// </summary>
        public bool IncludeLanguageRules { get; set; }

        /// <summary>
        /// Указывает, нужно ли включить список <see cref="CertificateRuleDto"/>
        /// </summary>
        public bool IncludeCertificateRules { get; set; }

        public override IQueryable<CvSettings> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            query = AddHardSkillRules(query, IncludeHardSkillRules);
            query = AddProjectRules(query, IncludeProjectRules);
            query = AddProfessionalAbilityRules(query, IncludeProfessionalAbilityRules);
            query = AddCertificateRules(query, IncludeCertificateRules);
            query = AddEducationRules(query, IncludeEducationRules);
            query = AddLanguageRules(query, IncludeLanguageRules);

            return query;
        }

        public static IQueryable<CvSettings> AddHardSkillRules(IQueryable<CvSettings> query, bool includeHardSkills)
        {
            if (includeHardSkills)
            {
                query = query
                    .Include(cvs => cvs.HardSkillRules)
                    .ThenInclude(s => s.HardSkill);
            }

            return query;
        }

        public static IQueryable<CvSettings> AddProjectRules(IQueryable<CvSettings> query, bool includeProjects)
        {
            if (includeProjects)
            {
                query = query
                    .Include(cvs => cvs.ProjectRules)
                    .ThenInclude(s => s.ProjectRole);
            }

            return query;
        }

        public static IQueryable<CvSettings> AddProfessionalAbilityRules(IQueryable<CvSettings> query, bool includeProfessionalAbilities)
        {
            if (includeProfessionalAbilities)
            {
                query = query
                    .Include(cvs => cvs.ProfessionalAbilityRules);
            }

            return query;
        }

        public static IQueryable<CvSettings> AddCertificateRules(IQueryable<CvSettings> query, bool includeCertificates)
        {
            if (includeCertificates)
            {
                query = query
                    .Include(cvs => cvs.CertificateRules)
                    .ThenInclude(s => s.Certificate);
            }

            return query;
        }

        public static IQueryable<CvSettings> AddEducationRules(IQueryable<CvSettings> query, bool includeEducations)
        {
            if (includeEducations)
            {
                query = query
                    .Include(cvs => cvs.EducationRules)
                    .ThenInclude(s => s.Education);
            }

            return query;
        }

        public static IQueryable<CvSettings> AddLanguageRules(IQueryable<CvSettings> query, bool includeLanguages)
        {
            if (includeLanguages)
            {
                query = query
                    .Include(cvs => cvs.LanguageRules)
                    .ThenInclude(s => s.Language);
            }

            return query;
        }
    }
}
using System;
using System.Linq;
using CVGenerator.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Cv"/>
    /// </summary>
    public class CvFilter : BaseFilterModel<Cv, Guid, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public CvFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public CvFilter(Guid id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public CvFilter(Guid id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Идентификатор настроек CV
        /// </summary>
        public long? CvSettingsId { get; set; }

        /// <summary>
        /// Идентификатор владельца CV
        /// </summary>
        public long? EmployeeId { get; set; }

        /// <summary>
        /// Указывает, нужно ли возвращать <see cref="Employee"/>
        /// </summary>
        public bool IncludeEmployee { get; set; }

        /// <summary>
        /// Указывает, нужно ли возвращать <see cref="CvSettings"/>
        /// </summary>
        public bool IncludeCvSettings { get; set; }

        public override IQueryable<Cv> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (EmployeeId.HasValue)
            {
                query = query.Where(q => q.EmployeeId == EmployeeId);
            }

            if (CvSettingsId.HasValue)
            {
                query = query.Where(q => q.CvSettingsId == CvSettingsId);
            }

            query = AddEmployee(query, IncludeEmployee);
            query = AddCvSettings(query, IncludeCvSettings);

            return query;
        }

        private static IQueryable<Cv> AddEmployee(IQueryable<Cv> query, bool includeEmployee)
        {
            if (includeEmployee)
            {
                query = query.Include(cv => cv.Employee);
            }

            return query;
        }

        private static IQueryable<Cv> AddCvSettings(IQueryable<Cv> query, bool includeCvSettings)
        {
            if (includeCvSettings)
            {
                query = query
                    .Include(cv => cv.CvSettings)
                        .ThenInclude(cvs => cvs.HardSkillRules)
                            .ThenInclude(cvs => cvs.HardSkill)

                    .Include(cvs => cvs.CvSettings)
                        .ThenInclude(cvs => cvs.ProjectRules)
                            .ThenInclude(cvs => cvs.ProjectRole)

                    .Include(cvs => cvs.CvSettings)
                        .ThenInclude(cvs => cvs.ProfessionalAbilityRules)

                    .Include(cvs => cvs.CvSettings)
                        .ThenInclude(cvs => cvs.CertificateRules)
                            .ThenInclude(cvs => cvs.Certificate)

                    .Include(cvs => cvs.CvSettings)
                        .ThenInclude(cvs => cvs.EducationRules)
                            .ThenInclude(cvs => cvs.Education)

                    .Include(cvs => cvs.CvSettings)
                        .ThenInclude(cvs => cvs.LanguageRules)
                            .ThenInclude(cvs => cvs.Language);
            }

            return query;
        }
    }
}
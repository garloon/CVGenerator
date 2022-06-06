using System.Collections.Generic;
using CVGenerator.Core.Data.Entities;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels
{
    /// <summary>
    /// Модель для фильтрации <see cref="Department"/>
    /// </summary>
    public class DepartmentFilter : BaseFilterModel<Department, long, GeneratorContext>
    {
        /// <summary>
        /// Конструктор для фильтра без параметров.
        /// </summary>
        public DepartmentFilter() { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public DepartmentFilter(long id)
            : base(id) { }

        /// <summary>
        /// Конструктор для фильтра с одним идентификатором и флагом AsNoTracking.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="asNoTracking">Флаг AsNoTracking.</param>
        public DepartmentFilter(long id, bool asNoTracking)
            : base(id, asNoTracking) { }

        /// <summary>
        /// Наименование направления
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public string ExternalId { get; set; }

        // TODO: Для работы с внешними создать отедльный класс и интерфейс, его тут использовать гибко, подумать
        /// <summary> 
        /// Идентификаторы внешней системы
        /// </summary>
        public IEnumerable<string> ExternalIds { get; set; }

        /// <summary>
        /// Роль, в которое оценивается направление
        /// </summary>
        public Role? Role { get; set; }

        public override IQueryable<Department> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (Name != null)
            {
                query = query.Where(q => q.Name == Name);
            }

            if (!string.IsNullOrEmpty(ExternalId))
            {
                query = query.Where(q => q.ExternalId == ExternalId);
            }

            if (ExternalIds?.Count() > 0)
            {
                query = query.Where(q => ExternalIds.Contains(q.ExternalId));
            }

            if (Role.HasValue)
            {
                query = query.Where(q => q.Role == Role);
            }

            return query;
        }
    }
}
using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="Department"/>
    /// </summary>
    public class ExtendedDepartmentFilter : DepartmentFilter, IExtendedBaseFilterModel<Department, long, GeneratorContext>
    {
        /// <summary>
        /// Количество строк, которое нужно получить
        /// </summary>
        public int TakeCount { get; set; } = int.MaxValue;

        /// <summary>
        /// Количество строк, которое нужно пропустить
        /// </summary>
        public int SkipCount { get; set; }

        /// <summary>
        /// Поле для сортировки
        /// </summary>
        public string Ordering { get; set; } = "Id";

        /// <summary>
        /// Порядок сортировки по возрастанию? По умолчанию "true".
        /// </summary>
        public bool Ascending { get; set; } = true;

        /// <summary>
        /// Поиск подстроки наименования направления
        /// </summary>
        public string DepartmentNameSearching { get; set; }

        public override IQueryable<Department> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(DepartmentNameSearching))
            {
                query = query.Where(pr => pr.Name.Contains(DepartmentNameSearching));
            }

            query = this.AddOrder(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}
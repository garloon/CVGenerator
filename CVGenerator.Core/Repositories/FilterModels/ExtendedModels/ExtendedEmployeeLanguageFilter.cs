using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="EmployeeLanguage"/>
    /// </summary>
    public class ExtendedEmployeeLanguageFilter : EmployeeLanguageFilter, IExtendedBaseFilterModel<EmployeeLanguage, long, GeneratorContext>
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
        /// Поиск подстроки наименования языка
        /// </summary>
        public string LanguageNameSearching { get; set; }

        public override IQueryable<EmployeeLanguage> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(LanguageNameSearching))
            {
                query = query.Where(pr => pr.Language.Name.Contains(LanguageNameSearching));
            }

            query = this.AddOrder(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}
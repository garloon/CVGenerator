using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="Education"/>
    /// </summary>
    public class ExtendedEducationFilter : EducationFilter, IExtendedBaseFilterModel<Education, long, GeneratorContext>
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
        /// Поиск подстроки наименования
        /// </summary>
        public string SpecialtyNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки наименования университета
        /// </summary>
        public string UniversityNameSearching { get; set; }

        public override IQueryable<Education> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(SpecialtyNameSearching))
            {
                query = query.Where(pr => pr.SpecialtyName.Contains(SpecialtyNameSearching));
            }

            if (!string.IsNullOrEmpty(UniversityNameSearching))
            {
                query = query.Where(pr => pr.UniversityName.Contains(UniversityNameSearching));
            }

            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);
            query = this.AddOrder(query);

            return query;
        }
    }
}
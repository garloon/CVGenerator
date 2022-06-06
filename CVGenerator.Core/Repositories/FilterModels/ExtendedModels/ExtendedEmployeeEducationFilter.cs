using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="EmployeeEducation"/>
    /// </summary>
    public class ExtendedEmployeeEducationFilter : EmployeeEducationFilter, IExtendedBaseFilterModel<EmployeeEducation, long, GeneratorContext>
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
        /// Поиск подстроки наименования университета
        /// </summary>
        public string UniversityNameSearching { get; set; }

        /// <summary>
        /// Поиск подстроки наименования специальности
        /// </summary>
        public string SpecialtyNameSearching { get; set; }

        public override IQueryable<EmployeeEducation> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(UniversityNameSearching))
            {
                query = query.Where(pr => pr.Education.UniversityName.Contains(UniversityNameSearching));
            }

            if (!string.IsNullOrEmpty(SpecialtyNameSearching))
            {
                query = query.Where(pr => pr.Education.SpecialtyName.Contains(SpecialtyNameSearching));
            }

            query = this.AddOrder(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}
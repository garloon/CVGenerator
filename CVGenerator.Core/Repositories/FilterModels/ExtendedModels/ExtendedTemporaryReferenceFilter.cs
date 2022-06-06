using System;
using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="TemporaryReferenceFilter"/>
    /// </summary>
    public class ExtendedTemporaryReferenceFilter : TemporaryReferenceFilter, IExtendedBaseFilterModel<TemporaryReference, Guid, GeneratorContext>
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
        /// Поиск количества загрузок по ссылке.
        /// </summary>
        public int? NumberDownloadsSearching { get; set; }

        /// <summary>
        /// Поиск срока истечения.
        /// </summary>
        public DateTime? DateTimeSearching { get; set; }

        /// <summary>
        /// Условия поиска срока истечения.
        /// </summary>
        public string DateTimeSearchingCondition { get; set; }

        public override IQueryable<TemporaryReference> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (NumberDownloadsSearching.HasValue)
            {
                query = query.Where(pr => pr.NumberDownloads == NumberDownloadsSearching);
            }

            if (DateTimeSearching.HasValue && !string.IsNullOrEmpty(DateTimeSearchingCondition))
            {
                switch (DateTimeSearchingCondition)
                {
                    case "=":
                        query = query.Where(pr => pr.ExpirationTimeout == DateTimeSearching);
                        break;
                    case "!=":
                        query = query.Where(pr => pr.ExpirationTimeout != DateTimeSearching);
                        break;
                    case "<":
                        query = query.Where(pr => pr.ExpirationTimeout < DateTimeSearching);
                        break;
                    case "<=":
                        query = query.Where(pr => pr.ExpirationTimeout <= DateTimeSearching);
                        break;
                    case ">":
                        query = query.Where(pr => pr.ExpirationTimeout > DateTimeSearching);
                        break;
                    case ">=":
                        query = query.Where(pr => pr.ExpirationTimeout >= DateTimeSearching);
                        break;
                }
            }

            query = this.AddOrder(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}
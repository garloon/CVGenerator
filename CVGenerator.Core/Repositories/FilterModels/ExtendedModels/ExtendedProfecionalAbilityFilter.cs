using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    public class ExtendedProfecionalAbilityFilter : ProfessionalAbilityFilter, IExtendedBaseFilterModel<ProfessionalAbility, long, GeneratorContext>
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
        public string AbilityNameSearching { get; set; }

        public override IQueryable<ProfessionalAbility> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(AbilityNameSearching))
            {
                query = query.Where(pr => pr.Name.Contains(AbilityNameSearching));
            }

            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);
            query = this.AddOrder(query);

            return query;
        }
    }
}
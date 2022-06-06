using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;
using System.Linq;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    public class ExtendedHardSkillFilter : HardSkillFilter, IExtendedBaseFilterModel<HardSkill,long,GeneratorContext>
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
        /// Поиск подстроки наименования навыка
        /// </summary>
        public string TitleSearching { get; set; }

        /// <summary>
        /// Поиск подстроки кода навыка
        /// </summary>
        public string CodeSearching { get; set; }

        /// <summary>
        /// Поиск подстроки типа навыка
        /// </summary>
        public string TypeSearching { get; set; }

        public override IQueryable<HardSkill> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(TitleSearching))
            {
                query = query.Where(pr => pr.Title.Contains(TitleSearching));
            }

            if (!string.IsNullOrEmpty(CodeSearching))
            {
                query = query.Where(pr => pr.Code.Contains(CodeSearching));
            }

            if (!string.IsNullOrEmpty(TypeSearching))
            {
                query = query.Where(pr => pr.Type.Contains(TypeSearching));
            }

            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);
            query = this.AddOrder(query);

            return query;
        }
    }
}
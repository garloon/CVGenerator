using System;
using System.Collections.Generic;
using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="Cv"/>
    /// </summary>
    public class ExtendedCvFilter : CvFilter, IExtendedBaseFilterModel<Cv, Guid, GeneratorContext>
    {
        /// <summary>
        /// Взять записей 
        /// </summary>
        public int TakeCount { get; set; } = int.MaxValue;

        /// <summary>
        /// Количество записей для пропуска
        /// </summary>
        public int SkipCount { get; set; }

        /// <summary>
        /// Поле сортировки
        /// </summary>
        public string Ordering { get; set; } = "Id";

        /// <summary>
        /// Сортировка по возрастанию defult = true
        /// </summary>
        public bool Ascending { get; set; } = true;

        /// <summary>
        /// Название департамента
        /// </summary>
        public IEnumerable<string> Departments { get; set; }

        /// <summary>
        /// Поиск подстроки заголовка
        /// </summary>
        public string TitleSearching { get; set; }

        public override IQueryable<Cv> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(TitleSearching))
            {
                query = query.Where(pr => pr.Name.Contains(TitleSearching));
            }

            query = this.AddOrder(query);
            query = AddDepartment(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }

        private IQueryable<Cv> AddDepartment(IQueryable<Cv> query)
        {
            if (!(Departments?.Count() < 1))
            {
                return query;
            }

            if (Departments.Count() == 1)
            {
                var department = Departments.FirstOrDefault();
                query = query.Where(m => m.DepartmentName.Equals(department));
            }
            else
            {
                query = query.Where(m => Departments.Contains(m.DepartmentName));
            }

            return query;
        }
    }
}
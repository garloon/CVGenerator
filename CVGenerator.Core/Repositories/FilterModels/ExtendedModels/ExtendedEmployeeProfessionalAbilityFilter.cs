﻿using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    /// <summary>
    /// Расширеная модель для фильтрации <see cref="EmployeeProfessionalAbility"/>
    /// </summary>
    public class ExtendedEmployeeProfessionalAbilityFilter : EmployeeAbilityFilter, IExtendedBaseFilterModel<EmployeeProfessionalAbility, long, GeneratorContext>
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
        public string AbilityNameSearching { get; set; }

        public override IQueryable<EmployeeProfessionalAbility> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(AbilityNameSearching))
            {
                query = query.Where(pr => pr.ProfessionalAbility.Name.Contains(AbilityNameSearching));
            }

            query = this.AddOrder(query);
            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}
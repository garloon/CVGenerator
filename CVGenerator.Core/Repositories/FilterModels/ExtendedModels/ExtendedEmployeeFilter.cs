using System.Linq;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels.Interfaces;

namespace CVGenerator.Core.Repositories.FilterModels.ExtendedModels
{
    public class ExtendedEmployeeFilter : EmployeeFilter, IExtendedBaseFilterModel<Employee, long, GeneratorContext>
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
        /// Поиск подстроки ФИО.
        /// </summary>
        public string NameSubStringSearching { get; set; }

        /// <summary>
        /// Поиск подстроки логина.
        /// </summary>
        public string LoginSearching { get; set; }

        /// <summary>
        /// Поиск подстроки E-mail.
        /// </summary>
        public string EmailSearching { get; set; }

        public override IQueryable<Employee> GetQueryable(GeneratorContext context)
        {
            var query = base.GetQueryable(context);

            if (!string.IsNullOrEmpty(NameSubStringSearching))
            {
                query = query.Where(pr =>
                    (pr.FirstName + " " + pr.MiddleName + " " + pr.LastName)
                    .Contains(NameSubStringSearching));
            }

            if (!string.IsNullOrEmpty(LoginSearching))
            {
                query = query.Where(pr => pr.Login
                    .Contains(LoginSearching));
            }

            if (!string.IsNullOrEmpty(EmailSearching))
            {
                query = query.Where(pr => pr.Email
                    .Contains(EmailSearching));
            }

            switch (Ordering)
            {
                case "FirstLastMiddleName":
                    query = Ascending
                        ? query.OrderBy(e => e.FirstName + e.MiddleName + e.LastName) 
                        : query.OrderByDescending(e => e.FirstName + e.MiddleName + e.LastName);
                        break;
                default:
                    query = this.AddOrder(query);
                    break;
            }

            query = this.AddSkipCount(query);
            query = this.AddTakeCount(query);

            return query;
        }
    }
}
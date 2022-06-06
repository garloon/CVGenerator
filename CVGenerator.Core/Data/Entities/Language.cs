using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Иностранный язык
    /// </summary>
    public class Language : EntityBase<int>
    {
        /// <summary>
        /// Наименование языка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сотрудники владеющие языком
        /// </summary>
        public ICollection<EmployeeLanguage> Employees { get; set; }

        public Language()
        {
            Employees = new HashSet<EmployeeLanguage>();
        }
    }
}

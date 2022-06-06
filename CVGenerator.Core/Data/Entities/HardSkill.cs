using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Навык
    /// </summary>
    public class HardSkill : EntityBase<long>, IExternal<long?>
    {
        public string Code { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public bool IsActual { get; set; }

        public bool IsUsed { get; set; }

        public int Level { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Идентификатор родительского навыка
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Сотрудники владеющие навыком
        /// </summary>
        public ICollection<EmployeeHardSkill> Employees { get; set; }

        /// <summary>
        /// Проекты, на которых используется технология (= навык для сотрудника)
        /// </summary>
        public ICollection<ProjectHardSkill> Projects { get; set; }

        public HardSkill()
        {
            Projects = new HashSet<ProjectHardSkill>();
            Employees = new HashSet<EmployeeHardSkill>();
        }
    }
}

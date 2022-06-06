using System;
using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project : EntityBase<long>, IExternal<string>
    {
        /// <summary>
        /// Наименование проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата старта проекта
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>        
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Актуальный ли проект на данный момент
        /// </summary>
        public bool IsActual { get; set; }

        /// <summary>
        /// Личный проект пользователя? (пет. или с прошлого места работы)
        /// </summary>
        public bool IsPersonal { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Сотрудники проекта
        /// </summary>
        public ICollection<EmployeeProject> Employees { get; set; }

        /// <summary>
        /// Технологии проекта
        /// </summary>
        public ICollection<ProjectHardSkill> HardSkills { get; set; }

        public Project()
        {
            Employees = new HashSet<EmployeeProject>();
            HardSkills = new HashSet<ProjectHardSkill>();
        }
    }
}

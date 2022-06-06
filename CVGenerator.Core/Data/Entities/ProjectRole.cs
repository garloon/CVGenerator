using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Роль сотрудника на проекте
    /// </summary>
    public class ProjectRole : EntityBase<int>
    {
        /// <summary>
        /// Короткое название (абривиатура)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Наименование роли на проекте
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Наименование роли от пользователя?
        /// </summary>
        public bool IsPersonal { get; set; }

        /// <summary>
        /// Коллекция проектов, на которых используется данная роль
        /// </summary>
        public ICollection<EmployeeProject> Projects { get; set; }

        public ProjectRole()
        {
            Projects = new HashSet<EmployeeProject>();
        }
    }
}

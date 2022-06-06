using System;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Проекты сотрудника
    /// </summary>
    public class EmployeeProject : EntityBase<long>
    {
        /// <summary>
        /// Название проекта, которое будет видеть клиент,
        /// </summary>
        public string ShowName { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string DescriptionProject { get; set; }

        /// <summary>
        /// Описание задач, которые сотрудник выполнял на проекте 
        /// </summary>
        public string MyTasks { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Идентификатор роли на проекте
        /// </summary>
        public int? ProjectRoleId { get; set; }

        /// <summary>
        /// Дата начала работы на проекте
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания работы на проекте
        /// </summary>        
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Проект
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// Роль на проекте
        /// </summary>
        public virtual ProjectRole ProjectRole { get; set; }
    }
}

using System;

namespace CVGenerator.Core.Data.Entities.Rules
{
    /// <summary>
    /// Правила заполнения информации о проектах
    /// </summary>
    public class ProjectRule : BaseRule
    {
        /// <summary>
        /// Название проекта, которое будет видеть клиент,
        /// </summary>
        public string ShowName { get; set; }

        /// <summary>
        /// Описание задач, которые сотрудник выполнял на проекте 
        /// </summary>
        public string MyTasks { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string DescriptionProject { get; set; }

        /// <summary>
        /// Дата начала работы на проекте
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания работы на проекте
        /// </summary>        
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Идентификатор роли на проекте
        /// </summary>
        public int ProjectRoleId { get; set; }

        /// <summary>
        /// Роль на проекте
        /// </summary>
        public virtual ProjectRole ProjectRole { get; set; }

        public bool Equals(ProjectRule projectRule)
        {
            return ShowName == projectRule.ShowName &&
                   MyTasks == projectRule.ShowName &&
                   StartDate == projectRule.StartDate &&
                   EndDate == projectRule.EndDate &&
                   ProjectRoleId == projectRule.ProjectRoleId;
        }
    }
}

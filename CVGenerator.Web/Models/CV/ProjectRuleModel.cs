using System;

namespace CVGenerator.Web.Models.Cv
{
    public class ProjectRuleModel : BaseRuleModal
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
        /// Роль на проекте
        /// </summary>
        public ProjectRoleModel ProjectRole { get; set; }

        /// <summary>
        /// Идентификатор роли на проекте
        /// </summary>
        public int ProjectRoleId { get; set; }
    }
}
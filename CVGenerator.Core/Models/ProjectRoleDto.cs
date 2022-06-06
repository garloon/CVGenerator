namespace CVGenerator.Core.Models
{
    public class ProjectRoleDto : BaseDto<int?>
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
    }
}
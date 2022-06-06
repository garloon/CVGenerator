
namespace CVGenerator.Web.Models.QueryFilters
{
    public class EmployeeQueryFilter
    {
        /// <summary>
        /// Строка, которая должна содержаться в имени сотрудника
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Локация
        /// </summary>
        public string Location { get; set; } = string.Empty;

        public bool IsShowDismissed { get; set; } = false;

        public int Page { get; set; }
    }
}

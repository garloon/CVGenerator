namespace CVGenerator.Web.Models.QueryFilters
{
    /// <summary>
    /// Фильтр отображения <see cref="CvViewModel"/>
    /// </summary>
    public class CvQueryFilter
    {
        /// <summary>
        /// Строка, которая должна содержаться в фио сотрудника
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Отделы по которому отображаются Cv
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Локация
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Включить архивные записи
        /// </summary>
        public bool IsArchive { get; set; }

        /// <summary>
        /// Страница
        /// </summary>
        public int Page { get; set; }
    }
}

namespace CVGenerator.Web.Models.Cv
{
    public class BaseRuleModal
    {
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор настроек
        /// </summary>
        public long CvSettingsId { get; set; }

        /// <summary>
        /// Показывать в резюме?
        /// </summary>
        public bool IsShow { get; set; }
    }
}

namespace CVGenerator.Core.Models.Cv
{
    public class BaseRuleDto : BaseDto<long>
	{
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
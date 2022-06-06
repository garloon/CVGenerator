namespace CVGenerator.Core.Data.Entities.Rules
{
    public abstract class BaseRule : EntityBase<long>
	{
		/// <summary>
		/// Идентификатор настроек
		/// </summary>
		public long CvSettingsId { get; set; }

		/// <summary>
		/// Настройки CV
		/// </summary>
		public virtual CvSettings CvSettings { get; set; }

		/// <summary>
		/// Показывать в резюме?
		/// </summary>
		public bool IsShow { get; set; }
	}
}

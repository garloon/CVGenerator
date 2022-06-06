using System;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Временная ссылка
    /// </summary>
    public class TemporaryReference : EntityBase<Guid>
	{
		/// <summary>
		/// Таймаут сгорания ссылки.
		/// </summary>
		public DateTime ExpirationTimeout { get; set; }

		/// <summary>
		/// Идентификатор CV, которое будет скачено
		/// </summary>
		public Guid CvId { get; set; }

		/// <summary>
		/// TODO: В сущность статистики
		/// Количество произведенных загрузок по ссылке
		/// </summary>
		public int NumberDownloads { get; set; }

		public virtual Cv Cv { get; set; }
	}
}

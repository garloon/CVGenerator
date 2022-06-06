using System;
using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Резюме
    /// </summary>
    public class Cv : EntityBase<Guid>
    {
        /// <summary>
        /// Наименование Cv
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Наименование направления
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Идентификатор настроек Cv
        /// </summary>
        public long CvSettingsId { get; set; }

        /// <summary>
        /// Настройки Cv
        /// </summary>
        public virtual CvSettings CvSettings { get; set; }

        /// <summary>
        /// Идентификатор владельца Cv
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Владелец Cv
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Комментарий к записи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Временные ссылки для сгенерированного Cv
        /// </summary>
        public virtual ICollection<TemporaryReference> TemporaryReferences { get; set; }

        public Cv()
        {
            TemporaryReferences = new HashSet<TemporaryReference>();
        }
    }
}

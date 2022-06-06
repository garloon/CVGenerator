using System;
using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Образование
    /// </summary>
    public class Education : EntityBase<long>
    {
        /// <summary>
        /// Название учебного заведения
        /// </summary>
        public string UniversityName { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        public string SpecialtyName { get; set; }

        /// <summary>
        /// Тип специальности
        /// </summary>
        public TypeSpecialty TypeSpecialty { get; set; }

        /// <summary>
        /// Год начала обучения
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// Год окончания обучения
        /// </summary>        
        public DateTime? FinishDate { get; set; }

        public ICollection<EmployeeEducation> Employees { get; set; }

        public Education()
        {
            Employees = new HashSet<EmployeeEducation>();
        }
    }
}

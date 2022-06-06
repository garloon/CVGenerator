using System.Collections.Generic;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : EntityBase<long>, IExternal<long?>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeeStatus Status { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Направления сотрудника
        /// </summary>
        public ICollection<EmployeeDepartment> Departments { get; set; }

        /// <summary>
        /// Языки сотрудника
        /// </summary>
        public ICollection<EmployeeLanguage> Languages { get; set; }

        /// <summary>
        /// Образование сотрудника
        /// </summary>
        public ICollection<EmployeeEducation> Educations { get; set; }

        /// <summary>
        /// Сертификаты сотрудника
        /// </summary>
        public ICollection<EmployeeCertificate> Certificates { get; set; }

        /// <summary>
        /// Профессиональные навыки сотрудника
        /// </summary>
        public ICollection<EmployeeProfessionalAbility> ProfessionalAbilities { get; set; }

        /// <summary>
        /// Навыки сотрудника
        /// </summary>
        public ICollection<EmployeeHardSkill> HardSkills { get; set; }

        /// <summary>
        /// Проекты сотрудника
        /// </summary>
        public ICollection<EmployeeProject> Projects { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Cv> Cvs { get; set; }

        public Employee()
        {
            Departments = new HashSet<EmployeeDepartment>();
            Languages = new HashSet<EmployeeLanguage>();
            Educations = new HashSet<EmployeeEducation>();
            Certificates = new HashSet<EmployeeCertificate>();
            ProfessionalAbilities = new HashSet<EmployeeProfessionalAbility>();
            HardSkills = new HashSet<EmployeeHardSkill>();
            Projects = new HashSet<EmployeeProject>();
            Cvs = new HashSet<Cv>();
        }
    }
}

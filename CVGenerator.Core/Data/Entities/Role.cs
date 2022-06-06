using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Роль в системе
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Не задано
        /// </summary>
        [Display(Name = "Не задано")]
        None = 0,

        /// <summary>
        /// Сотрудники из направлений: 
        /// Прочие сотрудники
        /// </summary>
        [Display(Name = "Прочие сотрудники")]
        Common,

        /// <summary>
        /// Сотрудники из направлений: 
        /// PM (менеджер проекта), Account-менеджер, Sales
        /// </summary>
        [Display(Name = "PM (менеджер проекта), Account-менеджер, Sales")]
        Account,

        /// <summary>
        /// Сотрудники из направлений: 
        /// РН/РО (Руководитель направления/Руководитель отдела), Presale направления
        /// </summary>
        [Display(Name = "РН/РО (Руководитель направления/Руководитель отдела), Presale направления")]
        Supervisor,

        /// <summary>
        /// Сотрудники из направлений: 
        /// Администратор направления сопровождения БП, Топ-менеджмент 
        /// </summary>
        [Display(Name = "Администратор направления сопровождения БП, Топ-менеджмент")]
        Administrator
    }
}

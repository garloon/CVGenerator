namespace CVGenerator.Core.Data.Constants
{
    public static class AvailableRoles
    {
        /// <summary>
        /// Сотрудники из направлений: 
        /// PM (менеджер проекта), Account-менеджер, Sales
        /// </summary>
        public const string Account = "Account";

        /// <summary>
        /// Сотрудники из направлений: 
        /// РН/РО (Руководитель направления/Руководитель отдела), Presale направления
        /// </summary>
        public const string Supervisor = "Supervisor";

        /// <summary>
        /// Сотрудники из направлений: 
        /// Администратор направления сопровождения БП, Топ-менеджмент 
        /// </summary>
        public const string Administrator = "Administrator";
    }
}

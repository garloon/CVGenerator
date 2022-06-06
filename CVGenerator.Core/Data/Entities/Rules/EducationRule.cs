namespace CVGenerator.Core.Data.Entities.Rules
{
    /// <summary>
    /// Правила заполнения информации об образовании
    /// </summary>
    public class EducationRule : BaseRule
    {
        /// <summary>
        /// Идентификатор образования
        /// </summary>
        public long EducationId { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public virtual Education Education { get; set; }

        public bool Equals(EducationRule educationRule)
        {
            return EducationId == educationRule.EducationId;
        }
    }
}

namespace CVGenerator.Core.Data.Entities.Rules
{
    /// <summary>
    /// Правила заполнения информации о профессиональных навыков и умения в CV
    /// </summary>
    public class ProfessionalAbilityRule : BaseRule
    {
        public string Name { get; set; }

        public bool Equals(ProfessionalAbilityRule professionalAbilityRule)
        {
            return Name == professionalAbilityRule.Name;
        }
    }
}

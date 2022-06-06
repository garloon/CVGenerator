namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Профессиональные навыки и умения = Competence
    /// </summary>
    public class ProfessionalAbility : EntityBase<long>, IExternal<long?>
    {
        public string Name { get; set; }

        public long PositionId { get; set; }

        public bool Required { get; set; }

        public long SectionId { get; set; }

        public long? ExternalId { get; set; }
    }
}

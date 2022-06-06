using System.Collections.Generic;
using CVGenerator.Core.Models.External;
using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Operations.Synchronize.HardSkills
{
    // TODO: Другое название
    public class HardSkillsSynchronizeModel
    {
        public List<HardSkill> OurHardSkills { get; set; }
        public List<ExternalHardSkill> ExternalHardSkills { get; set; }
    }
}

using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.HardSkills
{
    public class HardSkillsSynchronizeRequest
    {
        public List<ExternalHardSkill> ExternalHardSkills { get; set; }
        public List<ExternalHardSkill> ExternalHardSkillTree { get; set; }
    }
}

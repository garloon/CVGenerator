using CVGenerator.Core.Data.Entities.Rules;
using CVGenerator.Core.Repositories.FilterModels.Rules;
using CVGenerator.Core.Repositories.Interfaces.Rules;

namespace CVGenerator.Core.Repositories.Rules
{
    public class CertificateRuleRepository : BaseRepository<CertificateRule, long, GeneratorContext, CertificateRuleFilter>, ICertificateRuleRepository
    {
        public CertificateRuleRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}
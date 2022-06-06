using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class CertificateRepository : BaseRepository<Certificate, long, GeneratorContext, CertificateFilter>, ICertificateRepository
    {
        public CertificateRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}
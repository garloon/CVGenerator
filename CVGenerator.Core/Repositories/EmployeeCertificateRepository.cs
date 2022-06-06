using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class EmployeeCertificateRepository : BaseRepository<EmployeeCertificate, long, GeneratorContext, EmployeeCertificateFilter>, IEmployeeCertificateRepository
    {
        public EmployeeCertificateRepository(GeneratorContext context)
          : base(context)
        {
        }
    }
}
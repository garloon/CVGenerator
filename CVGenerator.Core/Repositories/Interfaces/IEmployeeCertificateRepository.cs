using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface IEmployeeCertificateRepository : IBaseRepository<EmployeeCertificate, long, GeneratorContext, EmployeeCertificateFilter>
    {
    }
}
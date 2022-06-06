using System;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface ICvRepository : IBaseRepository<Cv, Guid, GeneratorContext, CvFilter>
    {
    }
}

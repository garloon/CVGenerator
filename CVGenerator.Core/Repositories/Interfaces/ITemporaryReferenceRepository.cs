using System;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;

namespace CVGenerator.Core.Repositories.Interfaces
{
    public interface ITemporaryReferenceRepository : IBaseRepository<TemporaryReference, Guid, GeneratorContext, TemporaryReferenceFilter>
    {
    }
}
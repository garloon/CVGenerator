using System;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class TemporaryReferenceRepository : BaseRepository<TemporaryReference, Guid, GeneratorContext, TemporaryReferenceFilter>, ITemporaryReferenceRepository
    {
        public TemporaryReferenceRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

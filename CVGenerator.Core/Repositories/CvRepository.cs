using System;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Repositories
{
    public class CvRepository : BaseRepository<Cv, Guid, GeneratorContext, CvFilter>, ICvRepository
    {
        public CvRepository(GeneratorContext context)
            : base(context)
        {
        }
    }
}

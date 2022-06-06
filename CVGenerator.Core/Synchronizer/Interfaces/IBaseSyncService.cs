using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer.Interfaces
{
    public interface IBaseSyncService
    {
        Task<Exception> RunAsync();
    }
}

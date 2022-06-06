using CVGenerator.Core.Operations;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Synchronizer.Interfaces;
using CVGenerator.Core.Synchronizer.SynchronizeServices;
using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;
using Microsoft.Extensions.Logging;

namespace CVGenerator.Core.Synchronizer
{
    public class SynchronizeFactory : ISynchronizeFactory
    {
        private readonly ILogger<SynchronizeFactory> _logger;
        private readonly ICvOperations _operations;
        private readonly IRequestHelper _requestHelper;

        public SynchronizeFactory(ILogger<SynchronizeFactory> logger, ICvOperations operations, IRequestHelper requestHelper)
        {
            _requestHelper = requestHelper;
            _operations = operations;
            _logger = logger;
        }

        public ISynchronizeCertificateService CreateSynchronizeCertificateService()
        {
            return new SynchronizeCertificateService(_requestHelper, _operations, _logger);
        }

        public ISynchronizeDepartmentService CreateSynchronizeDepartmentService()
        {
            return new SynchronizeDepartmentService(_requestHelper, _operations, _logger);
        }

        public ISynchronizeEmployeeService CreateSynchronizeEmployeeService()
        {
            return new SynchronizeEmployeeService(_requestHelper, _operations, _logger);
        }

        public ISynchronizeHardSkillService CreateSynchronizeHardSkillService()
        {
            return new SynchronizeHardSkillService(_requestHelper, _operations, _logger);
        }

        public ISynchronizeProjectService CreateSynchronizeProjectService()
        {
            return new SynchronizeProjectService(_requestHelper, _operations, _logger);
        }
    }
}

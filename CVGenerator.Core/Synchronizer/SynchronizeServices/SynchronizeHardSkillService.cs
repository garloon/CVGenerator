using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CVGenerator.Core.Synchronizer.SynchronizeServices.Interfaces;
using CVGenerator.Core.RequestHelper;
using CVGenerator.Core.Operations;
using CVGenerator.Core.Operations.Synchronize.HardSkills;

namespace CVGenerator.Core.Synchronizer.SynchronizeServices
{
    public class SynchronizeHardSkillService : ISynchronizeHardSkillService
    {
        private readonly ILogger _logger;
        private readonly IRequestHelper _requestHelper;
        private readonly ICvOperations _operations;

        public SynchronizeHardSkillService(
            IRequestHelper requestHelper,
            ICvOperations operations,
            ILogger logger)
        {
            _requestHelper = requestHelper;
            _operations = operations;
            _logger = logger;
        }

        public async Task SynchronizeHardSkillsAsync()
        {
            try
            {
                _logger?.LogInformation("Началась синхронизация данных \"Навыки\"");

                var externalHardSkillTree = await _requestHelper.GetHardSkillTreeAsync();
                var externalHardSkills = await _requestHelper.GetHardSkillsAsync();

                var requestModel = new HardSkillsSynchronizeRequest
                {
                    ExternalHardSkillTree = externalHardSkillTree,
                    ExternalHardSkills = externalHardSkills
                };

                var operation = _operations.CreateHardSkillSynchronizeOperation();
                await operation.Execute(requestModel);

                _logger?.LogInformation("Данные по направлениям синхрониированы");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"При синхронизации данных \"Навыки\" возникла ошибка: {ex.Message}");
            }
        }
    }
}

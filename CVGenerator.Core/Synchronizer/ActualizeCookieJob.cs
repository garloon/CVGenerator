using CVGenerator.Core.Services;
using CVGenerator.Core.Services.Interfaces;
using CVGenerator.Core.Synchronizer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVGenerator.Core.Synchronizer
{
    public class ActualizeCookieJob : IBaseSyncService
    {
        private readonly ILogger<ActualizeCookieJob> _logger;
        private readonly MeAuthService _authService;

        public ActualizeCookieJob(ILogger<ActualizeCookieJob> logger, MeAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public async Task<Exception> RunAsync()
        {
            return await MainJob();
        }

        private async Task<Exception> MainJob()
        {
            _logger.LogInformation("Фоновый процесс авторизации в ME запущен");

            try
            {
                _authService.ActualizeCookieContainer().Wait();
                _logger.LogInformation("Фоновый процесс авторизации в ME окончен");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Фоновый процесс авторизации вызвал ошибку: {e.Message}");
                throw;
            }
        }
    }
}

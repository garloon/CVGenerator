using CVGenerator.Core.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CVGenerator.Core.Services
{
    public class MeAuthService
    {
        private readonly ILogger<MeAuthService> _logger;

        private readonly MeSecurity _meSecurity;
        private readonly MeUri _meUri;

        public MeAuthService(ILogger<MeAuthService> logger, IOptions<MeSecurity> meSecurity, IOptions<MeUri> meUri)
        {
            _logger = logger;
            _meSecurity = meSecurity.Value;
            _meUri = meUri.Value;
        }

        public CookieContainer CookieContainer { get; private set; }

        public async Task ActualizeCookieContainer()
        {
            try
            {
                var cookieContainer = new CookieContainer();
                var httpClientHandler = new HttpClientHandler { CookieContainer = cookieContainer };
                var httpClient = new HttpClient(httpClientHandler);

                var uri = new Uri(_meUri.BaseUrlAddress + _meUri.AuthUrl);

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
                {
                    Content = new StringContent(JsonSerializer.Serialize(new
                    {
                        password = _meSecurity.Password,
                        username = _meSecurity.Login,
                    }), 
                    Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(httpRequestMessage);
                CookieContainer = cookieContainer;

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Авторизация успешно выполнена");
                }
                else
                {
                    _logger.LogError($"Авторизация не выполнена. {(int)response.StatusCode}: {response.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Ошибка при попытке авторизации в сервисе Me: {e.Message}");
            }
        }
    }
}

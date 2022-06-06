using CVGenerator.Core.Configurations;
using CVGenerator.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace CVGenerator.Core.RequestHelper
{
    public class HttpClientBuilder
    {
        private readonly MeAuthService _meAuthService;
        private readonly MeUri _meUri;

        public HttpClientBuilder(MeAuthService meAuthService, IOptions<MeUri> meUri)
        {
            _meAuthService = meAuthService;
            _meUri = meUri.Value;
        }

        public HttpClient CreateHttpClient()
        {
            var baseAddress = new Uri(_meUri.BaseUrlAddress);
            var handler = CreateHandler();

            var client = new HttpClient(handler);
            client.BaseAddress = baseAddress;

            return client;
        }

        public HttpClientHandler CreateHandler()
        {
            var cookieContainer = _meAuthService.CookieContainer;
            var handler = new HttpClientHandler { CookieContainer = cookieContainer };

            return handler;
        }
    }
}

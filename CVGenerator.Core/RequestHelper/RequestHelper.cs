using CVGenerator.Core.Configurations;
using CVGenerator.Core.Models.External;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CVGenerator.Core.RequestHelper
{
    public class RequestHelper : IRequestHelper
    {
        private readonly ILogger<RequestHelper> _logger;

        private readonly HttpClientBuilder _httpClientBuilder;
        private readonly MeUri _meUri;

        public RequestHelper(ILogger<RequestHelper> logger, HttpClientBuilder httpClientBuilder, IOptions<MeUri> meUri)
        {
            _logger = logger;
            _httpClientBuilder = httpClientBuilder;
            _meUri = meUri.Value;
        }

        public async Task<List<ExternalDepartment>> GetDepartmentsAsync()
        {
            var response = await GetResponseAsync(_meUri.DepartmentServiceUrl);
            return DeserializeObjectsResponse<ExternalDepartment>(response);
        }

        public async Task<List<ExternalEmployee>> GetEmployeesAsync()
        {
            var response = await GetResponseAsync(_meUri.EmployeesServiceUrl);
            return DeserializeObjectsResponse<ExternalEmployee>(response);
        }

        public async Task<List<ExternalCertificate>> GetCertificatesAsync()
        {
            var response = await GetResponseAsync(_meUri.CertificateServiceUrl);
            return DeserializeObjectsResponse<ExternalCertificate>(response);
        }

        public async Task<List<ExternalHardSkill>> GetHardSkillsAsync()
        {
            var response = await GetResponseAsync(_meUri.HardSkillServiceUrl);
            return DeserializeObjectsResponse<ExternalHardSkill>(response);
        }

        public async Task<List<ExternalHardSkill>> GetHardSkillTreeAsync()
        {
            var response = await GetResponseAsync(_meUri.HardSkillTreeServiceUrl);
            return DeserializeObjectsResponse<ExternalHardSkill>(response);
        }

        public async Task<List<ExternalProject>> GetProjectsAsync()
        {
            var response = await GetResponseAsync(_meUri.ProjectServiceUrl);
            return DeserializeObjectsResponse<ExternalProject>(response);
        }

        public async Task<ExternalEmployee> GetEmployeeAsync(long employeeId)
        {
            var response = await GetResponseAsync(_meUri.EmployeeServiceUrl + employeeId);
            return DeserializeObjectResponse<ExternalEmployee>(response);
        }

        public async Task<List<ExternalEmployeeCertificate>> GetEmployeeCertificateAsync(long employeeId)
        {
            var response = await GetResponseAsync(_meUri.EmployeeCertificateUrl + employeeId);
            return DeserializeObjectsResponse<ExternalEmployeeCertificate>(response);
        }

        public async Task<List<ExternalEmployeeHardSkill>> GetEmployeeHardSkillAsync(long employeeId)
        {
            var response = await GetResponseAsync(_meUri.EmployeeHardSkillUrl + employeeId);
            return DeserializeObjectsResponse<ExternalEmployeeHardSkill>(response);
        }

        private async Task<string> GetResponseAsync(string serviceUrl)
        {

            var client = _httpClientBuilder.CreateHttpClient();

            var result = await client.GetAsync(_meUri.BaseUrlAddress + serviceUrl);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }

            throw new Exception($"Ответ запроса: {result.StatusCode} - {result.Content.ReadAsStringAsync()}");
        }

        private TValue DeserializeObjectResponse<TValue>(string response)
        {
            return JsonSerializer.Deserialize<TValue>(response);
        }

        private List<TValue> DeserializeObjectsResponse<TValue>(string response)
        {
            return JsonSerializer.Deserialize<List<TValue>>(response);
        }
    }
}

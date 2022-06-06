using CVGenerator.Core.Data.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CVGenerator.Core.Models.External
{
    public class ExternalEmployee
    {
        /// <summary>
        /// Идентификатор во внешней системе
        /// </summary>
        [JsonPropertyName("id")]
        public long? ExternalId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("departments")]
        public List<ExternalDepartment> Departments { get; set; }
    }
}

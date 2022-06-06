using System.Threading.Tasks;
using CVGenerator.Core.Models;

namespace CVGenerator.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<EmployeeDto> LoginAsync(string login, string password);
    }
}

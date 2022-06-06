using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Models;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Services.Interfaces;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

namespace CVGenerator.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly LdapOptions _options;
        private readonly IGeneratorRepository _repository;
        private readonly IMapper _mapper;
        private readonly SuperAdminUser _superAdminUser;

        public AuthenticationService(
            IGeneratorRepository repository,
            IOptions<LdapOptions> options,
            IMapper mapper,
            IOptions<SuperAdminUser> superAdminUser)
        {
            _repository = repository;
            _options = options.Value;
            _mapper = mapper;
            _superAdminUser = superAdminUser.Value;
        }

        public const long SUPERADMIN_USER_ID = 10;

        private bool IsSuperAdmin(string login, string password)
        {
            return _superAdminUser.Login == login &&
                _superAdminUser.Password == password;
        }

        public async Task<EmployeeDto> LoginAsync(string login, string password)
        {
            if (IsSuperAdmin(login, password))
            {
                return new EmployeeDto
                {
                    Id = SUPERADMIN_USER_ID,
                    Login = _superAdminUser.Login,
                    Role = Role.Administrator,
                    Name = "superadmin"
                };
            }

            // Проверка логина и пароля пользователя
            using (var connection = new LdapConnection())
            {
                try
                {
                    connection.Connect(_options.Url, _options.Port);
                }
                catch (Exception e)
                {
                    throw new ApplicationException(e.Message);
                }

                try
                {
                    var distinguishedName = "cn=People,dc=simbirsoft";
                    var scope = 2;
                    var filter = $"(uid={login})";
                    var attributes = Array.Empty<string>();
                    var ldapEntry = connection
                                   .Search(distinguishedName, scope, filter, attributes, true)
                                   .FirstOrDefault();

                    connection.Bind(ldapEntry?.Dn, password);
                }
                catch (Exception e)
                {
                    throw new AuthenticationException(e.Message);
                }
            }

            // Получение данных пользователя из БД
            var employee = await _repository.Employee.GetFirstOrDefaultAsync(new EmployeeFilter { Login = login });

            if (employee == null)
            {
                throw new AuthenticationException();
            }

            // Получение списка направлений сотрудника
            var employeeDepartments = await _repository.EmployeeDepartment.GetAsync(
                new EmployeeDepartmentFilter
                {
                    EmployeeId = employee.Id,
                    IncludeDepartment = true,
                    AsNoTracking = true
                });

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            employeeDto.Role = GetMaxRoleEmployee(employeeDepartments);

            return employeeDto;
        }

        private Role GetMaxRoleEmployee(List<EmployeeDepartment> employeeDepartments)
        {
            var roleGrades = employeeDepartments.Select(d => Convert.ToInt32(d.Department.Role));
            var maxGrade = roleGrades.Max();
            var maxRole = (Role)Enum.GetValues(typeof(Role)).GetValue(maxGrade);

            return maxRole;
        }
    }
}
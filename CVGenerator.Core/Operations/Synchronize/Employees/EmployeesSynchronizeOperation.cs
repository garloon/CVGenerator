using CVGenerator.Core.Repositories.FilterModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using CVGenerator.Core.Models.External;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;

namespace CVGenerator.Core.Operations.Synchronize.Employees
{
    public class EmployeesSynchronizeOperation : Operation<EmployeesSynchronizeRequest, EmployeesSynchronizeModel>
    {
        private readonly ILogger _logger;

        public EmployeesSynchronizeOperation(IGeneratorRepository repository, ILogger logger)
            : base(repository)
        {
            _logger = logger;
        }

        protected override async Task<EmployeesSynchronizeModel> Materialize(EmployeesSynchronizeRequest request)
        {
            var model = new EmployeesSynchronizeModel
            {
                OurEmployees = await _repository.Employee
                    .GetAsync(new EmployeeFilter { AsNoTracking = true })
            };

            foreach (var employee in request.ExternalEmployees)
            {
                if (Enum.TryParse(employee.Status, out EmployeeStatus status))
                {
                    employee.EmployeeStatus = status;
                }
            }

            return model;
        }

        protected override async Task Apply(Context context)
        {
            var employeesToAdd = new List<Data.Entities.Employee>();
            var employeesToModify = new List<Data.Entities.Employee>();

            // Добавление и обновление информации в БД
            foreach (var externalEmployee in context.Request.ExternalEmployees)
            {
                try
                {
                    var ourEmployee = context.Model.OurEmployees.FirstOrDefault(emp => emp.ExternalId == externalEmployee.ExternalId);

                    // Проверка необходимости внесения изменений в данные сотрудника
                    if (IsUpdate(externalEmployee, ourEmployee))
                    {
                        var updateEmployee = new Data.Entities.Employee();

                        if (ourEmployee != null)
                        {
                            updateEmployee = await _repository.Employee.GetFirstOrDefaultAsync(new EmployeeFilter(ourEmployee.Id));

                            if (updateEmployee == null)
                            {
                                throw new Exception($"Запись с Id {ourEmployee.Id} не найдена");
                            }

                            // Если в систему пришел сотрудник у которого статус "Активен", а у нас он "НЕ Активен
                            // То значит он восстановился и обнуляем ему дату увольнения 
                            updateEmployee.Deleted = null;
                        }

                        UpdateFields(externalEmployee, updateEmployee);

                        // Проверка корректности добавляемой/изменяемой модели
                        if (CheckNull(updateEmployee))
                        {
                            _logger?.LogError($"Не удалось добавить объект ExternalId - '{externalEmployee?.ExternalId?.ToString() ?? "null"}'. " +
                                "Отсутствуют значения одного или несколько обязательных полей");

                            continue;
                        }

                        if (ourEmployee == null)
                        {
                            employeesToAdd.Add(updateEmployee);
                        }
                        else
                        {
                            employeesToModify.Add(updateEmployee);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, $"Ошибка при обработке объекта ExternalId - '{externalEmployee?.ExternalId?.ToString() ?? "null"}'. " +
                        "Обработка объекта пропущена");
                }
            }

            try
            {
                // Добавление моделей в БД
                if (employeesToAdd.Count > 0)
                {
                    await _repository.Employee.AddAsync(employeesToAdd);
                }

                // Изменение моделей БД
                if (employeesToModify.Count > 0)
                {
                    await _repository.Employee.ModifyAsync(employeesToModify);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Ошибка при добавлении или модификации данных о сотрудниках");
            }

            await SynchronizeDepartments(context);

            // Удаление из БД записей с внешним Id, которые не найдены в полученном списке
            var externalIds = context.Model.OurEmployees
                .Where(emp => emp.ExternalId.HasValue)
                .Select(emp => emp.ExternalId)
                .Except(context.Request.ExternalEmployees.Select(emp => emp.ExternalId))
                .ToList();

            if (externalIds.Count > 0)
            {
                var firedEmployees = await _repository.Employee.GetAsync(new EmployeeFilter { ExternalIds = externalIds });

                foreach (var firedEmployee in firedEmployees)
                {
                    firedEmployee.Status = EmployeeStatus.INACTIVE;
                    firedEmployee.Deleted = DateTime.UtcNow;
                }

                await _repository.Employee.ModifyAsync(firedEmployees);
            }
        }

        private async Task SynchronizeDepartments(Context context)
        {
            try
            {
                var ourEmployees = await _repository.Employee
                    .GetAsync(new EmployeeFilter { AsNoTracking = true });

                foreach (var externalEmployee in context.Request.ExternalEmployees)
                {
                    var ourEmployee = ourEmployees.FirstOrDefault(emp => emp.ExternalId == externalEmployee.ExternalId);

                    if (ourEmployee == null)
                    {
                        continue;
                    }

                    // Получение списка направлений из БД
                    var ourEmplDepartments = await _repository.EmployeeDepartment.GetAsync(
                        new EmployeeDepartmentFilter
                        {
                            EmployeeId = ourEmployee.Id,
                            IncludeDepartment = true
                        });

                    // Список для удаления из БД
                    var departmentsToDelete = ourEmplDepartments
                        .Where(dep => externalEmployee.Departments.All(extDep => dep.Department.ExternalId != extDep.ExternalId))
                        .ToList();

                    // Список для добавления в БД
                    var departmentsToAdd = externalEmployee.Departments
                        .Where(extDep => ourEmplDepartments.All(dep => dep.Department.ExternalId != extDep.ExternalId))
                        .ToList();

                    // Удаление направлений сотрудника
                    if (departmentsToDelete.Count() > 0)
                    {
                        await _repository.EmployeeDepartment.DeleteAsync(departmentsToDelete);
                    }

                    // Добавление направлений сотрудника
                    foreach (var extDep in departmentsToAdd)
                    {
                        try
                        {
                            var ourDepartment = await _repository.Department
                                .GetFirstOrDefaultAsync(new DepartmentFilter { ExternalId = extDep.ExternalId });

                            if (ourDepartment != null)
                            {
                                // Добавление существующего направлений 
                                await _repository.EmployeeDepartment.AddAsync(new EmployeeDepartment
                                {
                                    EmployeeId = ourEmployee.Id,
                                    DepartmentId = ourDepartment.Id
                                });
                            }
                            else
                            {
                                // Добавление нового направления
                                await _repository.EmployeeDepartment.AddAsync(new EmployeeDepartment
                                {
                                    EmployeeId = ourEmployee.Id,
                                    Department = new Department
                                    {
                                        ExternalId = extDep.ExternalId,
                                        Name = extDep.Name
                                    }
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger?.LogError(ex, "Ошибка при добавлении или модификации данных о направлении сотрудника " +
                                $"(Employee.ExternalId - {externalEmployee.ExternalId}, " +
                                $"Department.ExternalId - {extDep?.ExternalId ?? "null"})");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Ошибка при синхронизции данных по направлениям сотрудников");
            }
        }

        private static void UpdateFields(ExternalEmployee externalEmployee, Data.Entities.Employee updateEmployee)
        {
            updateEmployee.ExternalId = externalEmployee.ExternalId;
            updateEmployee.Login = externalEmployee.Login;
            updateEmployee.FirstName = externalEmployee.FirstName;
            updateEmployee.LastName = externalEmployee.LastName;
            updateEmployee.MiddleName = externalEmployee.MiddleName;
            updateEmployee.Email = externalEmployee.Email;
            updateEmployee.Status = externalEmployee.EmployeeStatus;
        }

        private static bool CheckNull(Data.Entities.Employee updateEmployee)
        {
            return string.IsNullOrEmpty(updateEmployee.Login) ||
                   string.IsNullOrEmpty(updateEmployee.FirstName) ||
                   string.IsNullOrEmpty(updateEmployee.LastName) ||
                   string.IsNullOrEmpty(updateEmployee.Email);
        }

        private static bool IsUpdate(ExternalEmployee externalEmployee, Data.Entities.Employee ourEmployee)
        {
            return ourEmployee == null ||
                   ourEmployee.Login != externalEmployee.Login ||
                   ourEmployee.FirstName != externalEmployee.FirstName ||
                   ourEmployee.LastName != externalEmployee.LastName ||
                   ourEmployee.MiddleName != externalEmployee.MiddleName ||
                   ourEmployee.Email != externalEmployee.Email ||
                   ourEmployee.Status != externalEmployee.EmployeeStatus;
        }

        protected override Task Validate(Context context)
        {
            return Task.CompletedTask;
        }
    }
}
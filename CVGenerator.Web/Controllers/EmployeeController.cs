using AutoMapper;
using CVGenerator.Core;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Extensions;
using CVGenerator.Core.Initializers;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.FilterModels.ExtendedModels;
using CVGenerator.Core.Synchronizer.Interfaces;
using CVGenerator.Web.Models;
using CVGenerator.Web.Models.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CVGenerator.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private const int SHOW_ON_PAGE = 30;
        private const int SHOW_ON_SEARCHPAGE = 20;

        private readonly IConfiguration _configuration;
        private readonly IGeneratorRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISynchronizeFactory _synchronizeFactory;

        public EmployeeController(IConfiguration configuration, IGeneratorRepository repository, IMapper mapper, ISynchronizeFactory synchronizeFactory)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
            _synchronizeFactory = synchronizeFactory;
        }

        [HttpGet("Access")]
        public async Task<IActionResult> Access(EmployeeQueryFilter filter)
        {
            try
            {
                // Расчет количества страниц
                int pageCount = await GetPageCount(filter);

                // Получение списка сотрудников
                var employees = await GetEmployees(filter);
                List<EmployeeAccessModel> emplAccesses = GetRole(employees);

                ViewData["QueryFilter"] = filter;
                ViewData["QueryFilterString"] = GetFilterString(filter);

                ViewData["TableTitle"] = "Доступ пользователей";
                ViewData["ControllerName"] = "Employee/Access";


                ViewData["PageNum"] = filter.Page;
                ViewData["PageCount"] = pageCount;

                return View("Access", emplAccesses);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        private async Task<int> GetPageCount(EmployeeQueryFilter filter)
        {
            long countObj = await _repository.Employee.GetCountAsync(new EmployeeFilter { NameSubString = filter.Name });

            int pageCount = (int)Math.Ceiling(1.0 * countObj / SHOW_ON_PAGE);

            filter.Page = Math.Min(filter.Page, pageCount);
            filter.Page = Math.Max(filter.Page, 1);
            return pageCount;
        }

        private async Task<List<Employee>> GetEmployees(EmployeeQueryFilter filter)
        {
            return (await _repository.Employee
                .GetAsync(new ExtendedEmployeeFilter
                {
                    Status = EmployeeStatus.ACTIVE,
                    SkipCount = (filter.Page - 1) * SHOW_ON_PAGE,
                    NameSubString = filter.Name,
                    IncludeDepartments = true,
                    AsNoTracking = true
                }))
                .ToList();
        }

        private List<EmployeeAccessModel> GetRole(List<Employee> employees)
        {
            var emplAccesses = new List<EmployeeAccessModel>();

            foreach (var empl in employees)
            {
                var access = _mapper.Map<EmployeeAccessModel>(empl);

                access.IsAdministrator = empl.Departments?.Any(dep => dep.DepartmentId == DepartmentInitializer.AdministratorId) ?? false;
                access.IsAccount = empl.Departments?.Any(dep => dep.DepartmentId == DepartmentInitializer.AccountId) ?? false;
                access.IsSupervisor = empl.Departments?.Any(dep => dep.DepartmentId == DepartmentInitializer.SupervisorId) ?? false;

                emplAccesses.Add(access);
            }

            return emplAccesses;
        }

        [HttpPost("Access/SaveChanges")]
        public async Task<IActionResult> SaveChanges([FromBody] List<EmployeeAccessModel> changedObj)
        {
            try
            {
                bool res = true;

                foreach (var obj in changedObj)
                {
                    var emplDepartments = (await _repository.EmployeeDepartment
                        .GetAsync(new EmployeeDepartmentFilter { EmployeeId = obj.EmployeeId }))
                        .ToList();

                    // Установка признака IsAdministrator
                    res &= await SetEmployeeRole(obj.IsAdministrator, obj.EmployeeId,
                        DepartmentInitializer.AdministratorId, emplDepartments);

                    // Установка признака IsSupervisor
                    res &= await SetEmployeeRole(obj.IsSupervisor, obj.EmployeeId,
                        DepartmentInitializer.SupervisorId, emplDepartments);

                    // Установка признака IsAccount
                    res &= await SetEmployeeRole(obj.IsAccount, obj.EmployeeId,
                        DepartmentInitializer.AccountId, emplDepartments);
                }

                if (!res)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Устанавливает или снимает признак роли сотрудника
        /// </summary>
        /// <param name="setRole">True, если необходимо установить признак</param>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="roleDepartmentId">Идентификатор направления, соответсвующий признаку</param>
        /// <param name="emplDepartments">Список направлений сотрудника</param>
        private async Task<bool> SetEmployeeRole(
            bool setRole, long employeeId, long roleDepartmentId,
            IReadOnlyCollection<EmployeeDepartment> emplDepartments)
        {
            try
            {
                var emplDepartment = emplDepartments.FirstOrDefault(dep => dep.DepartmentId == roleDepartmentId);

                if (setRole && emplDepartments.All(dep => dep.DepartmentId != roleDepartmentId))
                {
                    await _repository.EmployeeDepartment.AddAsync(new EmployeeDepartment
                    {
                        EmployeeId = employeeId,
                        DepartmentId = roleDepartmentId
                    });
                }
                else if (emplDepartment != null)
                {
                    await _repository.EmployeeDepartment.DeleteAsync(emplDepartment);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("{employeeId}/Details")]
        public async Task<IActionResult> Details(long employeeId)
        {
            var employee = await _repository.Employee.GetAllEmployeeDetails(employeeId);
            var details = _mapper.Map<EmployeeDetailsModel>(employee);

            return View("Details", details);
        }

        [HttpGet]
        public async Task<IActionResult> Index(EmployeeQueryFilter filter)
        {
            var departments = await _repository.Department.GetAsync(new DepartmentFilter { AsNoTracking = true });

            var departmentsSelect = departments
                .Where(department => !department.IsLocation && !department.IsApplicationDepartment);

            ViewBag.DepartmentsSelect = _mapper.Map<List<DepartmentSelect>>(departmentsSelect);
            ViewBag.LocationSelect = _mapper.Map<List<DepartmentSelect>>(departments.Where(department => department.IsLocation));

            var departmentId = departments.FirstOrDefault(d => d.Name == filter.Department)?.Id;
            var locationId = departments.FirstOrDefault(d => d.Name == filter.Location)?.Id;

            // Если показывать уволенных = false, то показываем только активных
            var employeeStatus = !filter.IsShowDismissed
                ? EmployeeStatus.ACTIVE
                : EmployeeStatus.INACTIVE;

            var countFilter = new EmployeeFilter
            {
                NameSubString = filter.Name,
                DepartmentId = departmentId,
                LocationId = locationId
            };

            // Расчет количества страниц
            var countObj = await _repository.Employee.GetCountAsync(countFilter);

            var pageCount = (int)Math.Ceiling(1.0 * countObj / SHOW_ON_PAGE);

            filter.Page = Math.Min(filter.Page, pageCount);
            filter.Page = Math.Max(filter.Page, 1);

            ViewData["PageNum"] = filter.Page;
            ViewData["PageCount"] = pageCount;
            ViewBag.IsShowDismissed = filter.IsShowDismissed;

            var employeesFilter = new ExtendedEmployeeFilter
            {
                NameSubString = filter.Name,
                AsNoTracking = true,
                TakeCount = SHOW_ON_SEARCHPAGE,
                SkipCount = (filter.Page - 1) * SHOW_ON_PAGE,
                DepartmentId = departmentId,
                LocationId = locationId,
                Status = employeeStatus
            };

            var employees = await _repository.Employee.GetAsync(employeesFilter);

            var employeesModel = _mapper.Map<List<EmployeeSearchingModel>>(employees);

            return View("Index", employeesModel);
        }

        /// <summary>
        /// Синхронизация данных пользователя
        /// </summary>
        [HttpPost("{employeeId}/Synchronize"), ValidateAntiForgeryToken]
        public async Task<IActionResult> SynchronizeAsync(SynchUserTemp model)
        {
            var user = await _repository.Employee.GetFirstOrDefaultAsync(new EmployeeFilter(model.EmployeeId));

            if (user == null || !user.ExternalId.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            var synchronizeEmployeeService = _synchronizeFactory.CreateSynchronizeEmployeeService();
            await synchronizeEmployeeService.SynchronizeEmployeeAsync(user.ExternalId.Value);

            return Redirect($"/Employee/{model.EmployeeId}/Details");
        }

        /// <summary>
        /// Формирует url-строку с фильтром
        /// </summary>
        private static string GetFilterString(EmployeeQueryFilter filter)
        {
            if (filter == null)
            {
                return string.Empty;
            }

            var filterParams = new List<string>();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterParams.Add($"name={WebUtility.UrlEncode(filter.Name)}");
            }

            if (filterParams.Count < 1)
            {
                return string.Empty;
            }

            return string.Join('&', filterParams);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using CVGenerator.Core.Repositories.FilterModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CVGenerator.Core.Models.External;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;

namespace CVGenerator.Core.Operations.Synchronize.Departments
{
    public class DepartmentsSynchronizeOperation : Operation<DepartmentsSynchronizeRequest, DepartmentsSynchronizeModel>
    {
        private readonly ILogger _logger;

        public DepartmentsSynchronizeOperation(IGeneratorRepository repository, ILogger logger)
            : base(repository)
        {
            _logger = logger;
        }

        protected override async Task<DepartmentsSynchronizeModel> Materialize(DepartmentsSynchronizeRequest request)
        {
            return new DepartmentsSynchronizeModel
            {
                OurDepartments = await _repository.Department
                    .GetAsync(new DepartmentFilter { AsNoTracking = true })
            };
        }

        protected override async Task Apply(Context context)
        {
            foreach (var externalDepartment in context.Request.ExternalDepartments)
            {
                try
                {
                    var ourDepartment = context.Model.OurDepartments
                        .FirstOrDefault(prj => prj.ExternalId == externalDepartment.ExternalId);

                    if (IsUpdate(externalDepartment, ourDepartment))
                    {
                        var updateDepartment = new Department { ExternalId = externalDepartment.ExternalId };

                        if (ourDepartment != null)
                        {
                            updateDepartment = await _repository.Department.GetFirstOrDefaultAsync(
                                new DepartmentFilter(ourDepartment.Id));

                            if (updateDepartment == null)
                            {
                                throw new Exception($"Запись с Id {ourDepartment.Id} не найдена");
                            }
                        }

                        updateDepartment.Name = externalDepartment.Name;

                        if (string.IsNullOrEmpty(updateDepartment.Name))
                        {
                            _logger?.LogError($"Не удалось добавить объект ExternalId - '{externalDepartment.ExternalId ?? "null"}'. " +
                                "Отсутствуют значения одного или несколько обязательных полей");

                            continue;
                        }

                        if (ourDepartment == null)
                        {
                            await _repository.Department.AddAsync(updateDepartment);
                        }
                        else
                        {
                            await _repository.Department.ModifyAsync(updateDepartment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, $"Ошибка при обработке объекта ExternalId - '{externalDepartment?.ExternalId ?? "null"}'. " +
                        "Обработка объекта пропущена");
                }

                // Удаление из БД записей с внешним Id, которые не найдены в полученном списке
                // TODO: Рассмотреть вариант не удаления, а Deleted = DateTime.Now
                var externalIds = context.Model.OurDepartments
                        .Where(od => !string.IsNullOrEmpty(od.ExternalId))
                        .Select(od => od.ExternalId)
                        .Except(context.Request.ExternalDepartments.Select(ed => ed.ExternalId))
                        .ToList();

                if (externalIds.Count > 0)
                {
                    var deleteDepartments = await _repository.Department.GetAsync(new DepartmentFilter { ExternalIds = externalIds });

                    await _repository.Department.DeleteAsync(deleteDepartments);
                }
            }
        }

        private static bool IsUpdate(ExternalDepartment externalDepartment, Department entityDepartment)
        {
            return entityDepartment == null || entityDepartment.Name != externalDepartment.Name;
        }

        protected override Task Validate(Context context)
        {
            return Task.CompletedTask;
        }
    }
}
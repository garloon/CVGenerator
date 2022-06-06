using CVGenerator.Core.Repositories.FilterModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CVGenerator.Core.Models.External;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;

namespace CVGenerator.Core.Operations.Synchronize.Projects
{
    public class ProjectsSynchronizeOperation : Operation<ProjectsSynchronizeRequest, ProjectsSynchronizeModel>
    {
        private readonly ILogger _logger;

        public ProjectsSynchronizeOperation(IGeneratorRepository repository, ILogger logger)
            : base(repository)
        {
            _logger = logger;
        }

        protected override async Task<ProjectsSynchronizeModel> Materialize(ProjectsSynchronizeRequest request)
        {

            //TODO: Проверки что все данные получены, все на месте

            var model = new ProjectsSynchronizeModel();

            // Получение из БД всех сотрудников
            model.OurEmployees = await _repository.Employee.GetAsync(new EmployeeFilter { AsNoTracking = true });

            // Получение из БД всех проектов
            model.OurProjects = await _repository.Project.GetAsync(new ProjectFilter { AsNoTracking = true });

            // Получение из БД списка сотрудников, участвующих в проектах
            model.OurEmployeesProjects = await _repository.EmployeeProject.GetAsync(
                new EmployeeProjectFilter
                {
                    IncludeEmployee = true,
                    AsNoTracking = true
                });

            return model;
        }

        protected override async Task Apply(Context context)
        {
            // Добавление и обновление информации в БД
            foreach (var externalProject in context.Request.ExternalProjects)
            {
                try
                {
                    var ourProject = context.Model.OurProjects.FirstOrDefault(prj => prj.ExternalId == externalProject.ExternalId);

                    if (ourProject == null ||
                        ourProject.Name != externalProject.Name ||
                        ourProject.StartDate != externalProject.StartDate ||
                        ourProject.EndDate != externalProject.EndDate)
                    {
                        var updateProject = new Project { ExternalId = externalProject.ExternalId };

                        if (ourProject != null)
                        {
                            updateProject = await _repository.Project.GetFirstOrDefaultAsync(
                                new ProjectFilter(ourProject.Id));
                        }

                        updateProject.Name = externalProject.Name;
                        updateProject.StartDate = externalProject.StartDate;
                        updateProject.EndDate = externalProject.EndDate;

                        // Проверка корректности добавляемой/изменяемой модели
                        if (string.IsNullOrEmpty(updateProject.Name))
                        {
                            _logger?.LogError($"Не удалось добавить объект ExternalId - '{externalProject?.ExternalId ?? "null"}'. " +
                                "Отсутствуют значения одного или несколько обязательных полей");
                            continue;
                        }

                        if (ourProject == null)
                        {
                            await _repository.Project.AddAsync(updateProject);
                        }
                        else
                        {
                            await _repository.Project.ModifyAsync(updateProject);
                        }
                        ourProject = updateProject;
                    }

                    await SynchronizeEmployeeProjects(context, externalProject, ourProject);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, $"Ошибка при обработке объекта ExternalId - '{externalProject?.ExternalId ?? "null"}'. " +
                        "Обработка объекта пропущена");
                }
            }

            // Деактивация проектов
            var externalIds = context.Model.OurProjects
                .Where(prj => !string.IsNullOrEmpty(prj.ExternalId))
                .Select(prj => prj.ExternalId)
                .Except(context.Request.ExternalProjects.Select(prj => prj.ExternalId))
                .ToList();

            if (externalIds?.Count > 0)
            {
                var deletedProjects = await _repository.Project.GetAsync(new ProjectFilter { ExternalIds = externalIds });

                foreach (var deletedProject in deletedProjects)
                {
                    deletedProject.Deleted = DateTime.UtcNow;
                }

                await _repository.Project.ModifyAsync(deletedProjects);
            }
        }

        private async Task SynchronizeEmployeeProjects(Context context, ExternalProject externalProject, Project project)
        {
            var ourProjectMember = context.Model.OurEmployeesProjects.Where(pe => pe.ProjectId == project.Id).ToList();

            foreach (var member in externalProject.ProjectMembers)
            {
                try
                {
                    var ourMember = ourProjectMember.FirstOrDefault(m => m.Employee.ExternalId.Value == member.ExternalId);
                    var ourEmployee = context.Model.OurEmployees.FirstOrDefault(e => e.ExternalId == member.ExternalId);


                    if (ourMember == null)
                    {
                        await _repository.EmployeeProject.AddAsync(new EmployeeProject
                        {
                            EmployeeId = ourEmployee.Id,
                            ProjectId = project.Id,
                            EndDate = member.EndDate,
                            StartDate = member.StartDate
                        });
                    }
                    else
                    {
                        if (member.StartDate != ourMember.StartDate &&
                            member.EndDate != ourMember.EndDate)
                        {
                            ourMember.StartDate = member.StartDate;
                            ourMember.EndDate = member.EndDate;
                            await _repository.EmployeeProject.ModifyAsync(ourMember);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Ошибка при добавлении данных о проектах сотрудника");
                }
            }
        }

        // TODO: В будущем реализовать
        protected override async Task Validate(Context context)
        {
            await Task.CompletedTask;
        }
    }
}
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CV = CVGenerator.Core.Data.Entities.Cv;
using CVGenerator.Core.Extensions;
using CVGenerator.Core.Models.Cv;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using CVGenerator.Core.Models;
using System;

namespace CVGenerator.Core.Operations.Cv.Generate
{
    public class GenerateOperation : Operation<GenerateRequest, GenerateResponse, GenerateModel>
    {
        private readonly ILogger _logger;
        private readonly CvRulesBuilder _cvRulesBuilder;

        public GenerateOperation(IGeneratorRepository repository, ILogger logger, CvRulesBuilder cvRulesBuilder)
            : base(repository)
        {
            _cvRulesBuilder = cvRulesBuilder;
            _logger = logger;
        }

        protected override async Task<GenerateModel> Materialize(GenerateRequest request)
        {
            return new GenerateModel
            {
                Employee = await _repository.Employee.GetAllEmployeeDetails(request.EmployeeId)
            };
        }

        protected override async Task Validate(Context context)
        {
            //TODO: добавить проверку для Dto-шных правил

            if (context.Model.Employee.Projects.Any(p => p.ProjectRoleId == null))
            {
                var projectWithoutProjectRole =
                    context.Model.Employee.Projects.FirstOrDefault(p => p.ProjectRoleId == null);

                throw new Exception($"У проекта Id:{projectWithoutProjectRole.Id} не указана роль сотрудника на проекте");
            }

            if (context.Model.Employee.Projects.Any(p => string.IsNullOrEmpty(p.MyTasks)))
            {
                var projectWithoutMyTasks =
                    context.Model.Employee.Projects.FirstOrDefault(p => string.IsNullOrEmpty(p.MyTasks));

                throw new Exception($"У проекта Id:{projectWithoutMyTasks.Id} не указаны выполняемые задачи сотрудника на проекте");
            }

            if (context.Model.Employee.Projects.Any(p => string.IsNullOrEmpty(p.ShowName)))
            {
                var projectWithoutShowName =
                    context.Model.Employee.Projects.FirstOrDefault(p => string.IsNullOrEmpty(p.MyTasks));

                throw new Exception($"У проекта Id:{projectWithoutShowName.Id} не указано название для клиента");
            }

            if (context.Model.Employee.Projects.Any(p => string.IsNullOrEmpty(p.DescriptionProject)))
            {
                var projectWithoutDescription =
                    context.Model.Employee.Projects.FirstOrDefault(p => string.IsNullOrEmpty(p.DescriptionProject));

                throw new Exception($"У проекта Id:{projectWithoutDescription.Id} не указано название для клиента");
            }

            await Task.CompletedTask;
        }

        protected override async Task<GenerateResponse> Apply(Context context)
        {
            CV cv;

            if (context.Model.Cv == null)
            {
                cv = await GenerateFromEmployeeProfile(context.Model);

                return new GenerateResponse {CvId = cv.Id};
            }

            cv = await GenerateFromCv(context.Request.Cv, context.Request.CvSettings);

            return new GenerateResponse {CvId = cv.Id};
        }

        private async Task<CV> GenerateFromCv(CvDto requestCv, CvSettingsDto requestCvSettings)
        {
            var cvSettings = _repository.CvSettings.AddAndReturnEntityAsync(new CvSettings()).Result.Entity;

            await _cvRulesBuilder.CreateEducationRules(requestCvSettings.Id.Value, requestCvSettings.EducationRules);
            await _cvRulesBuilder.CreateLanguageRules(requestCvSettings.Id.Value, requestCvSettings.LanguageRules);
            await _cvRulesBuilder.CreateProfessionalAbilityRules(requestCvSettings.Id.Value, requestCvSettings.ProfessionalAbilityRules);
            await _cvRulesBuilder.CreateHardSkillRules(requestCvSettings.Id.Value, requestCvSettings.HardSkillRules);
            await _cvRulesBuilder.CreateProjectRules(requestCvSettings.Id.Value, requestCvSettings.ProjectRules);
            await _cvRulesBuilder.CreateCertificateRules(requestCvSettings.Id.Value, requestCvSettings.CertificateRules);

            var departments = requestCv.Employee.Departments
                .Where(d => d.IsForCv)
                .Select(d => d.Name)
                .ToList();

            var cv = new CV
            {
                CvSettingsId = cvSettings.Id,
                EmployeeId = requestCv.Employee.Id,
                Name = CreateCvName(requestCv.Employee),
                DepartmentName = string.Join(" ", departments)

            };

            await _repository.Cv.AddAsync(cv);

            return cv;
        }

        private async Task<CV> GenerateFromEmployeeProfile(GenerateModel model)
        {
            var cvSettings = _repository.CvSettings.AddAndReturnEntityAsync(new CvSettings()).Result.Entity;

            await _cvRulesBuilder.CreateEducationRules(cvSettings.Id, model.Employee.Educations);
            await _cvRulesBuilder.CreateLanguageRules(cvSettings.Id, model.Employee.Languages);
            await _cvRulesBuilder.CreateProfessionalAbilityRules(cvSettings.Id, model.Employee.ProfessionalAbilities);
            await _cvRulesBuilder.CreateHardSkillRules(cvSettings.Id, model.Employee.HardSkills);
            await _cvRulesBuilder.CreateProjectRules(cvSettings.Id, model.Employee.Projects);
            await _cvRulesBuilder.CreateCertificateRules(cvSettings.Id, model.Employee.Certificates);

            var departments = model.Employee.Departments
                .Where(d => d.Department.IsForCv)
                .Select(d => d.Department.Name)
                .ToList();

            var cv = new CV
            {
                CvSettingsId = cvSettings.Id,
                EmployeeId = model.Employee.Id,
                Name = CreateCvName(model.Employee),
                DepartmentName = string.Join(" ", departments)
            };

            await _repository.Cv.AddAsync(cv);

            return cv;
        }

        private string CreateCvName(EmployeeDto employee)
        {
            return CreateCvName(new Employee
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName
            });
        }

        private string CreateCvName(Employee employee)
        {
            var now = DateTime.Now;

            return employee.LastName +
                   employee.FirstName +
                   employee.MiddleName + "_" +
                   string.Concat(now.Date.Day, ".", now.Date.Month, ".", now.Date.Year) + "_" +
                   now.Hour + ":" + now.Minute;
        }
    }
}


/*
namespace Generator.Core.Operations.CV.Generate
{
    public class UpdateOperation : Operation<GenerateRequest, GenerateResponse, GenerateModel>
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
            var model = new GenerateModel();

            if (request.Cv != null)
            {
                model.Cv = await _repository.Cv.GetFirstOrDefaultAsync(new CvFilter
                {
                    Ids = new[] { request.Cv.Id },
                    IncludeEmployee = true
                });

                model.Settings = await _repository.CvSettings.GetAllCvRulesAsync(model.Cv.CvSettingsId);
            }

            model.Employee = await _repository.Employee.GetAllEmployeeDetails(request.EmployeeId);

            return model;
        }

        protected override async Task Validate(Context context)
        {
            if (context.Model.Employee.Projects.Any(p => p.ProjectRoleId == null))
            {
                var projectWithoutProjectRole =
                    context.Model.Employee.Projects.FirstOrDefault(p => p.ProjectRoleId == null);

                throw new Exception($"У проекта Id: {projectWithoutProjectRole.Id} не указана роль сотрудника");
            }

            await Task.CompletedTask;
        }

        protected override async Task<GenerateResponse> Apply(Context context)
        {
            (Cv cv, CvSettings settings) = (null, null);

            if (context.Model.Cv == null)
            {
                (cv, settings) = await GenerateNewCV(context.Model);

                return new GenerateResponse
                {
                    CV = cv,
                    Settings = settings
                };
            }

            await DeleteOldRules(context.Model.Settings);
            (cv, settings) = await UpdateCV(context.Request.Cv, context.Request.CvSettings, context.Model.Settings);

            return new GenerateResponse
            {
                CV = cv,
                Settings = settings
            };
        }

        private async Task DeleteOldRules(CvSettings cvSettings)
        {
            await _repository.CertificateRule.DeleteAsync(cvSettings.CertificateRules);
        }

        private async Task<(Cv, CvSettings)> UpdateCV(CvSettingsDto requestCvSettings, CvSettings cvSettings)
        {
            await _cvRulesBuilder.UpdateEducationRules(requestCvSettings.Id, requestCvSettings.EducationRules);
            await _cvRulesBuilder.UpdateLanguageRules(requestCvSettings.Id, requestCvSettings.LanguageRules);
            await _cvRulesBuilder.UpdateProfessionalAbilityRules(requestCvSettings.Id, requestCvSettings.ProfessionalAbilityRules);
            await _cvRulesBuilder.UpdateHardSkillRules(requestCvSettings.Id, requestCvSettings.HardSkillRules);
            await _cvRulesBuilder.UpdateProjectRules(requestCvSettings.Id, requestCvSettings.ProjectRules);
            await _cvRulesBuilder.UpdateCertificateRules(requestCvSettings.Id, requestCvSettings.CertificateRules);

            cv.Name = CreateCvName(cv.Employee);
            cv.Updated = DateTime.UtcNow;
            cvSettings.Updated = DateTime.UtcNow;

            await _repository.Cv.ModifyAsync(cv);

          //  var cvSettings = await _repository.CvSettings.GetAllCvRulesAsync(cv.CvSettingsId);

            return (cv, cvSettings);
        }

        private async Task<(Cv, CvSettings)> GenerateNewCV(GenerateModel model)
        {
            var cvSettings = _repository.CvSettings.AddAndReturnEntityAsync(new CvSettings()).Result.Entity;

            await _cvRulesBuilder.CreateEducationRules(cvSettings.Id, model.Employee.Educations);
            await _cvRulesBuilder.CreateLanguageRules(cvSettings.Id, model.Employee.Languages);
            await _cvRulesBuilder.CreateProfessionalAbilityRules(cvSettings.Id, model.Employee.ProfessionalAbilities);
            await _cvRulesBuilder.CreateHardSkillRules(cvSettings.Id, model.Employee.HardSkills);
            await _cvRulesBuilder.CreateProjectRules(cvSettings.Id, model.Employee.Projects);
            await _cvRulesBuilder.CreateCertificateRules(cvSettings.Id, model.Employee.Certificates);

            var cv = new Entities.Cv
            {
                CvSettingsId = cvSettings.Id,
                EmployeeId = model.Employee.Id,
                Name = CreateCvName(model.Employee)
            };

            await _repository.Cv.AddAsync(cv);

            cvSettings = await _repository.CvSettings.GetAllCvRulesAsync(cv.CvSettingsId);

            return (cv, cvSettings);
        }
        private string CreateCvName(Entities.Employee employee)
        {
            var now = DateTime.Now;

            return employee.LastName + 
                   employee.FirstName +
                   employee.MiddleName + "_" +
                   now.Date + "_" +
                   now.Hour + now.Minute;
        }
    }
}
*/
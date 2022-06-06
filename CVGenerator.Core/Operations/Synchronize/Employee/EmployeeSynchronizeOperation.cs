using CVGenerator.Core.Repositories.FilterModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;

namespace CVGenerator.Core.Operations.Synchronize.Employee
{
    public class EmployeeSynchronizeOperation : Operation<EmployeeSynchronizeRequest, EmployeeSynchronizeModel>
    {
        private readonly ILogger _logger;

        public EmployeeSynchronizeOperation(IGeneratorRepository repository, ILogger logger)
            : base(repository)
        {
            _logger = logger;
        }

        protected override async Task<EmployeeSynchronizeModel> Materialize(EmployeeSynchronizeRequest request)
        {
            var ourEmployee = await _repository.Employee
                .GetFirstOrDefaultAsync(new EmployeeFilter { ExternalId = request.ExternalEmployee.ExternalId });

            var ourEmployeeCertificates = await _repository.EmployeeCertificate
                .GetAsync(new EmployeeCertificateFilter { EmployeeId = ourEmployee.Id });

            var ourEmployeeDepartment = await _repository.EmployeeDepartment
                .GetAsync(new EmployeeDepartmentFilter
                {
                    IncludeDepartment = true,
                    EmployeeId = ourEmployee.Id
                });

            var ourEmployeeHardSkills = await _repository.EmployeeHardSkill
                .GetAsync(new EmployeeHardSkillFilter { EmployeeId = ourEmployee.Id });

            return new EmployeeSynchronizeModel
            {
                OurEmployee = ourEmployee,
                OurEmployeeCertificates = ourEmployeeCertificates,
                OurEmployeeDepartment = ourEmployeeDepartment,
                OurEmployeeHardSkills = ourEmployeeHardSkills,
            };
        }

        protected override async Task Apply(Context context)
        {
            var ourEmployee = context.Model.OurEmployee;
            var ourEmployeeCertificates = context.Model.OurEmployeeCertificates;
            var ourEmployeeDepartment = context.Model.OurEmployeeDepartment;
            var ourEmployeeHardSkills = context.Model.OurEmployeeHardSkills;

            if (ourEmployee.FirstName != context.Request.ExternalEmployee.FirstName ||
                ourEmployee.MiddleName != context.Request.ExternalEmployee.MiddleName ||
                ourEmployee.LastName != context.Request.ExternalEmployee.LastName)
            {
                ourEmployee.FirstName = context.Request.ExternalEmployee.FirstName;
                ourEmployee.MiddleName = context.Request.ExternalEmployee.MiddleName;
                ourEmployee.LastName = context.Request.ExternalEmployee.LastName;

                await _repository.Employee.ModifyAsync(ourEmployee);
            }

            foreach (var externalDepartment in context.Request.ExternalEmployee.Departments)
            {
                if (!ourEmployeeDepartment.Exists(d => d.Department.ExternalId == externalDepartment.ExternalId))
                {
                    var department = await _repository.Department
                        .GetFirstOrDefaultAsync(new DepartmentFilter { ExternalId = externalDepartment.ExternalId });

                    if (department == null)
                    {
                        _logger?.LogError($"Направление ExternalId: {externalDepartment.ExternalId} не найден в БД CV-Generator");
                        continue;
                    }

                    await _repository.EmployeeDepartment.AddAsync(new EmployeeDepartment
                    {
                        EmployeeId = ourEmployee.Id,
                        DepartmentId = department.Id
                    });
                }
            }

            foreach (var externalCertificate in context.Request.ExternalEmployeeCertificates)
            {
                if (!ourEmployeeCertificates.Exists(c => c.ExternalId == externalCertificate.ExternalId))
                {
                    var certificate = await _repository.Certificate
                        .GetFirstOrDefaultAsync(new CertificateFilter { ExternalId = externalCertificate.ExternalCertificateId });

                    if (certificate == null)
                    {
                        _logger?.LogError($"Сертификат ExternalId: {externalCertificate.ExternalCertificateId} не найден в БД CV-Generator");
                        continue;
                    }

                    await _repository.EmployeeCertificate.AddAsync(new EmployeeCertificate
                    {
                        ExternalId = externalCertificate.ExternalId,
                        EmployeeId = ourEmployee.Id,
                        CertificateId = certificate.Id
                    });
                }
            }

            foreach (var externalHardSkill in context.Request.ExternalEmployeeHardSkills)
            {
                if (!ourEmployeeHardSkills.Exists(c => c.ExternalId == externalHardSkill.ExternalId))
                {
                    var hardSkill = await _repository.HardSkill
                        .GetFirstOrDefaultAsync(new HardSkillFilter { ExternalId = externalHardSkill.HardSkill.ExternalId});

                    if (hardSkill == null)
                    {
                        _logger?.LogError($"Навык ExternalId: {externalHardSkill.ExternalId} не найден в БД CV-Generator");
                        continue;
                    }

                    var abilityLevel = ParseExternalAbilityLevel(externalHardSkill.AbilityLevel);

                    await _repository.EmployeeHardSkill.AddAsync(new EmployeeHardSkill
                    {
                        ExternalId = externalHardSkill.ExternalId,
                        EmployeeId = ourEmployee.Id,
                        HardSkillId = hardSkill.Id,
                        AbilityLevel = abilityLevel
                    });
                }
                else
                {
                    var ourEmployeeHardSkill = ourEmployeeHardSkills.FirstOrDefault(c => c.ExternalId == externalHardSkill.ExternalId);

                    var abilityLevel = ParseExternalAbilityLevel(externalHardSkill.AbilityLevel);

                    if (ourEmployeeHardSkill.AbilityLevel != abilityLevel)
                    {
                        ourEmployeeHardSkill.AbilityLevel = abilityLevel;
                        await _repository.EmployeeHardSkill.ModifyAsync(ourEmployeeHardSkill);
                    }
                }
            }
        }

        private AbilityLevel ParseExternalAbilityLevel(string externalAbilityLevel)
        {
            AbilityLevel abilityLevel = default;

            char[] abilityLevelChar = externalAbilityLevel.ToCharArray();

            for (int i = 1; i < abilityLevelChar.Length; i++)
            {
                abilityLevelChar[i] = char.ToLower(abilityLevelChar[i]);
            }

            if (Enum.TryParse(new string(abilityLevelChar), out AbilityLevel level))
            {
                abilityLevel = level;
            }

            return abilityLevel;
        }

        protected override Task Validate(Context context)
        {
            return Task.CompletedTask;
        }
    }
}
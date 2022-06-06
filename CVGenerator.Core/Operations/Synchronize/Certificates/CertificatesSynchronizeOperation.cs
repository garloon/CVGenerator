using CVGenerator.Core.Repositories.FilterModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CVGenerator.Core.Models.External;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;

namespace CVGenerator.Core.Operations.Synchronize.Certificates
{
    public class CertificatesSynchronizeOperation : Operation<CertificatesSynchronizeRequest, CertificatesSynchronizeModel>
    {
        private readonly ILogger _logger;

        public CertificatesSynchronizeOperation(IGeneratorRepository repository, ILogger logger)
            : base(repository)
        {
            _logger = logger;
        }

        protected override async Task<CertificatesSynchronizeModel> Materialize(CertificatesSynchronizeRequest request)
        {
            return new CertificatesSynchronizeModel
            {
                OurCertificates = await _repository.Certificate
                    .GetAsync(new CertificateFilter { AsNoTracking = true })
            };
        }

        protected override async Task Apply(Context context)
        {
            foreach (var externalCertificate in context.Request.ExternalCertificates)
            {
                try
                {
                    var ourCertificate = context.Model.OurCertificates
                        .FirstOrDefault(hardSkill => hardSkill.ExternalId == externalCertificate.ExternalId);

                    if (IsUpdate(externalCertificate, ourCertificate))
                    {
                        var updateCertificate = new Certificate { ExternalId = externalCertificate.ExternalId };

                        if (ourCertificate != null)
                        {
                            updateCertificate = await _repository.Certificate.GetFirstOrDefaultAsync(
                                new CertificateFilter(ourCertificate.Id));

                            if (updateCertificate == null)
                            {
                                throw new Exception($"Запись с Id {ourCertificate.Id} не найдена");
                            }
                        }

                        // change field
                        updateCertificate.Name = externalCertificate.Name;

                        // Проверка корректности добавляемой/изменяемой модели
                        if (string.IsNullOrEmpty(updateCertificate.Name))
                        {
                            _logger.LogError($"Не удалось добавить объект ExternalId - '{externalCertificate.ExternalId}'. " +
                                "Отсутствуют значения одного или несколько обязательных полей");

                            continue;
                        }

                        if (ourCertificate == null)
                        {
                            await _repository.Certificate.AddAsync(updateCertificate);
                        }
                        else
                        {
                            await _repository.Certificate.ModifyAsync(updateCertificate);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Ошибка при обработке объекта ExternalId - '{externalCertificate?.ExternalId.ToString()}'. " +
                        "Обработка объекта пропущена");
                }

                // Удаление из БД записей с внешним Id, которые не найдены в полученном списке
                var certificateIdsToDelete = context.Model.OurCertificates
                    .Where(cert => cert.ExternalId.HasValue)
                    .Select(cert => cert.ExternalId.Value)
                    .Except(context.Request.ExternalCertificates.Select(cert => cert.ExternalId))
                    .ToList();

                if (certificateIdsToDelete.Count() > 0)
                {
                    var certificatesToDelete = await _repository.Certificate.GetAsync(new CertificateFilter { ExternalIds = certificateIdsToDelete });
                    await _repository.Certificate.DeleteAsync(certificatesToDelete);
                }
            }
        }

        private static bool IsUpdate(ExternalCertificate externalCertificate, Certificate ourCertificate)
        {
            return ourCertificate == null ||
                   ourCertificate.Name != externalCertificate.Name;
        }

        protected override Task Validate(Context context)
        {
            return Task.CompletedTask;
        }
    }
}
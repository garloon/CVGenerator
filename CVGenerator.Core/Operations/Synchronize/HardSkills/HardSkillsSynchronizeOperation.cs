using CVGenerator.Core.Repositories.FilterModels;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.HardSkills
{
    public class HardSkillsSynchronizeOperation : Operation<HardSkillsSynchronizeRequest, HardSkillsSynchronizeModel>
    {
        private readonly ILogger _logger;

        public HardSkillsSynchronizeOperation(IGeneratorRepository repository, ILogger logger)
            : base(repository)
        {
            _logger = logger;
        }

        protected override async Task<HardSkillsSynchronizeModel> Materialize(HardSkillsSynchronizeRequest request)
        {
            var model = new HardSkillsSynchronizeModel
            {
                // Получение из БД всех скилов
                OurHardSkills = await _repository.HardSkill.GetAsync(new HardSkillFilter { AsNoTracking = true })
            };

            var skillGroups = new List<ExternalHardSkill>();
            CollectSkillGroups(request.ExternalHardSkillTree, ref skillGroups);

            model.ExternalHardSkills = new List<ExternalHardSkill>();
            model.ExternalHardSkills.AddRange(request.ExternalHardSkills);
            model.ExternalHardSkills.AddRange(skillGroups);

            return model;
        }

        private void CollectSkillGroups(List<ExternalHardSkill> hardSkills, ref List<ExternalHardSkill> skillGroups)
        {
            foreach (var hardSkill in hardSkills.Where(hardSkill => hardSkill.Type == "SKILL_GROUP"))
            {
                skillGroups.Add(hardSkill);

                if (hardSkill.Childrens != null)
                {
                    CollectSkillGroups(hardSkill.Childrens, ref skillGroups);
                }
            }
        }

        protected override async Task Apply(Context context)
        {
            // Добавление и обновление информации в БД
            foreach (var externalHardSkill in context.Model.ExternalHardSkills)
            {
                try
                {
                    var ourHardSkill = context.Model.OurHardSkills.FirstOrDefault(hardSkill => hardSkill.ExternalId == externalHardSkill.ExternalId);

                    if (ourHardSkill == null ||
                        ourHardSkill.Title != externalHardSkill.Title ||
                        ourHardSkill.Code != externalHardSkill.Code ||
                        ourHardSkill.Type != externalHardSkill.Type ||
                        ourHardSkill.IsActual != externalHardSkill.IsActual ||
                        ourHardSkill.IsUsed != externalHardSkill.IsUsed ||
                        ourHardSkill.Level != externalHardSkill.Level ||
                        ourHardSkill.Type != externalHardSkill.Type ||
                        ourHardSkill.ParentId != externalHardSkill.ParentId)
                    {
                        var updateHardSkill = new HardSkill { ExternalId = externalHardSkill.ExternalId };

                        if (ourHardSkill != null)
                        {
                            updateHardSkill = await _repository.HardSkill.GetFirstOrDefaultAsync(
                                new HardSkillFilter(ourHardSkill.Id));
                        }

                        updateHardSkill.Title = externalHardSkill.Title;
                        updateHardSkill.Code = externalHardSkill.Code;
                        updateHardSkill.Type = externalHardSkill.Type;
                        updateHardSkill.IsActual = externalHardSkill.IsActual;
                        updateHardSkill.IsUsed = externalHardSkill.IsUsed;
                        updateHardSkill.Level = externalHardSkill.Level;
                        updateHardSkill.Type = externalHardSkill.Type;
                        updateHardSkill.ParentId = externalHardSkill.ParentId;

                        // Проверка корректности добавляемой/изменяемой модели
                        if (string.IsNullOrEmpty(updateHardSkill.Title))
                        {
                            _logger?.LogError($"Не удалось добавить объект ExternalId - '{externalHardSkill?.ExternalId.ToString()}'. " +
                                "Отсутствуют значения одного или несколько обязательных полей");

                            continue;
                        }

                        if (ourHardSkill == null)
                        {
                            await _repository.HardSkill.AddAsync(updateHardSkill);
                        }
                        else
                        {
                            await _repository.HardSkill.ModifyAsync(updateHardSkill);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, $"Ошибка при обработке объекта ExternalId - '{externalHardSkill?.ExternalId.ToString()}'. " +
                        "Обработка объекта пропущена");
                }
            }

            // Деактивация проектов
            var externalIds = context.Model.OurHardSkills
                .Select(project => project.ExternalId.Value)
                .Except(context.Model.ExternalHardSkills.Select(prj => prj.ExternalId))
                .ToList();

            if (externalIds?.Count > 0)
            {
                var deletedHardSkills = await _repository.HardSkill.GetAsync(new HardSkillFilter { ExternalIds = externalIds });

                foreach (var deletedHardSkill in deletedHardSkills)
                {
                    deletedHardSkill.Deleted = DateTime.UtcNow;
                }

                await _repository.HardSkill.ModifyAsync(deletedHardSkills);
            }
        }

        // TODO: В будущем реализовать
        protected override async Task Validate(Context context)
        {
            await Task.CompletedTask;
        }
    }
}
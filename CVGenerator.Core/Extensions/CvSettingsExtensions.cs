using System.Threading.Tasks;
using CVGenerator.Core.Data.Entities;
using CVGenerator.Core.Repositories.FilterModels;
using CVGenerator.Core.Repositories.Interfaces;

namespace CVGenerator.Core.Extensions
{
    public static class CvSettingsExtensions
    {
        public static async Task<CvSettings> GetAllCvRulesAsync(this ICvSettingsRepository repository, long cvSettingsId)
        {
            return await repository.GetFirstOrDefaultAsync(new CvSettingsFilter(cvSettingsId)
            {
                IncludeProjectRules = true,
                IncludeCertificateRules = true,
                IncludeEducationRules = true,
                IncludeHardSkillRules = true,
                IncludeLanguageRules = true,
                IncludeProfessionalAbilityRules = true
            });
        }
    }
}
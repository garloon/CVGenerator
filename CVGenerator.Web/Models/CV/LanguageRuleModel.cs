

using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Web.Models.Cv
{
    public class LanguageRuleModel : BaseRuleModal
    {
        /// <summary>
        /// Уровень владения языком
        /// </summary>
        public LanguageLevel LanguageLevel { get; set; }

        /// <summary>
        /// Наименование языка
        /// </summary>
        public string Name { get; set; }
    }
}

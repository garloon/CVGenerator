using CVGenerator.Core.Data.Entities;

namespace CVGenerator.Core.Operations.Cv.Generate
{
    public class GenerateModel
    {
        /// <summary>
        /// Сотрудник, для кого создается Cv
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Имеющиеся настройки Cv
        /// </summary>
        public CvSettings Settings { get; set; }

        /// <summary>
        /// Резюме
        /// </summary>
        public Data.Entities.Cv Cv { get; set; }
    }
}

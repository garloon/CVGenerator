using CVGenerator.Core.Models.Cv;

namespace CVGenerator.Core.Operations.Cv.Generate
{
    public class GenerateRequest
    {
        public long EmployeeId { get; set; }

        public CvDto Cv { get; set; }

        public CvSettingsDto CvSettings { get; set; }
    }
}

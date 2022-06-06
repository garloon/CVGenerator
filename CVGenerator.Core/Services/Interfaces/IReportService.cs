using CVGenerator.Core.Models.Cv;

namespace CVGenerator.Core.Services.Interfaces
{
    public interface IReportService
    {
        byte[] GeneratePdfFromRazorView(CvDto cv);
    }
}

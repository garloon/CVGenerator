using System.Collections.Generic;
using CVGenerator.Core.Models.External;

namespace CVGenerator.Core.Operations.Synchronize.Certificates
{
    public class CertificatesSynchronizeRequest
    {
        public List<ExternalCertificate> ExternalCertificates { get; set; }
    }
}

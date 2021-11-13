using System.Diagnostics;

namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Installs certificates into the store.
    /// </summary>
    public class CertificateService : ICertificateService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public CertificateService()
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="path"><inheritdoc/></param>
        public void InstallCertificate(string path)
        {
            Process.Start("certutil.exe", $"-addstore -f Root {path}");
        }
    }
}

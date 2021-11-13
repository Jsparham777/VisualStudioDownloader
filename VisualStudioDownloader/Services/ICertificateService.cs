namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Certificate service for installing certificates into the store.
    /// </summary>
    public interface ICertificateService
    {
        /// <summary>
        /// Installs certificates into the store.
        /// </summary>
        /// <param name="path">The path to the certificate to install.</param>
        void InstallCertificate(string path);
    }
}
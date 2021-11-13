using VisualStudioDownloader.Models;

namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Bootstrapper interface.
    /// </summary>
    public interface IBootstrapperService
    {
        /// <summary>
        /// Identifies the bootstrapper attributes such as filename and version.
        /// </summary>
        /// <returns></returns>
        BootstrapperInfo IdentifyBootstrapper();

        /// <summary>
        /// Downloads the offline installation.
        /// </summary>
        void Download();

        /// <summary>
        /// Updates a previosuly downloaded offline installation.
        /// </summary>
        void Update();

        /// <summary>
        /// Installs the offline installation.
        /// </summary>
        void Install();

        /// <summary>
        /// Build the argument string by reading the arguments file used, to download the offline installation.
        /// </summary>
        /// <param name="isInstallation">Adds installation arguments.</param>
        /// <returns>The arguments.</returns>
        string BuildArguments(bool isInstallation = false);
    }
}
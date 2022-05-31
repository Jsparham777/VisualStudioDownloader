using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using VisualStudioDownloader.Models;

namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Provides boostrapper functionality.
    /// </summary>
    public class BootstrapperService : IBootstrapperService
    {
        private readonly IOptions<AppSettings> _options;
        private readonly IDownloadOptionsList _downloadOptionsList;
        private readonly IFileHandler _fileHandler;
        private readonly ICertificateService _certificateService;

        private readonly string _language = "--lang en-US";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">The application settings.</param>
        /// <param name="downloadOptionsList">The collection of download options.</param>
        /// <param name="fileHandler">The file handler.</param>
        /// <param name="certificateService">The certificate service.</param>
        public BootstrapperService(IOptions<AppSettings> options, IDownloadOptionsList downloadOptionsList, IFileHandler fileHandler, ICertificateService certificateService)
        {
            _options = options;
            _downloadOptionsList = downloadOptionsList;
            _fileHandler = fileHandler;
            _certificateService = certificateService;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>The bootstrapper information.</returns>
        public BootstrapperInfo IdentifyBootstrapper()
        {
            try
            {
                var file = FileVersionInfo.GetVersionInfo(_options.Value.BootstrapperPath);

                return new BootstrapperInfo
                {
                    ProductName = file.ProductName,
                    ProductVersion = file.ProductVersion,
                    Filename = Path.GetFileName(file.FileName),
                    FilePath = Path.GetFullPath(file.FileName),
                    Version = file.FileVersion
                };
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Could't find the bootstrapper!\n\n {ex.Message}\n\n Copy the bootstrapper the expected path.");
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Download()
        {
            var targetDir = Path.GetDirectoryName(_options.Value.BootstrapperPath);
            var arguments = $"--layout {targetDir}{ConstructArguments()} {_language}";

            // Store the argument string for running updates in the future
            _fileHandler.Write(arguments);

            Process.Start(_options.Value.BootstrapperPath, arguments);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Update()
        {
            // The original download command is run to update the offline cache. 
            if(!string.IsNullOrEmpty(BuildArguments()))
                Process.Start(_options.Value.BootstrapperPath, BuildArguments());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Install()
        {
            var path = $@"{Path.GetDirectoryName(_options.Value.BootstrapperPath)}\Certificates";
            var certificates = Directory.GetFiles(path);

            foreach (var certificate in certificates)
            {
                _certificateService.InstallCertificate(certificate);
            }
            
            Process.Start(_options.Value.BootstrapperPath, BuildArguments(true));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Clean()
        {
            string cleanPaths = string.Empty;

            var folders = GetArchiveFolderContents();

            // Get full path to each Catalog.json file in the GUID folder and add the clean switch
            foreach (var folder in folders)
            {
                var path = Path.Combine(folder, "Catalog.json");
                if(File.Exists(path))
                {
                    cleanPaths += $" --clean {path}";
                }
            }

            var targetDir = Path.GetDirectoryName(_options.Value.BootstrapperPath);
            var arguments = $"--layout {targetDir}{cleanPaths}";

            Process.Start(_options.Value.BootstrapperPath, arguments);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<string> GetArchiveFolderContents()
        {
            var path = Path.GetDirectoryName(IdentifyBootstrapper().FilePath);

            var dirInfo = new DirectoryInfo(Path.Combine(path, "Archive"));

            return dirInfo.GetDirectories().Select(x => x.FullName).ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="isInstallation"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public string BuildArguments(bool isInstallation = false)
        {
            var fileArgs = _fileHandler.Read();

            if (isInstallation)
            {
                string tempArgs = fileArgs.Replace(_language, "");

                var installArgs = Regex.Replace(tempArgs, "--layout .+? ", "");

                return $"{installArgs}--noweb";
            }

            return fileArgs;
        }

        /// <summary>
        /// Constructs the argument string.
        /// </summary>
        /// <returns>The constructed argument string.</returns>
        private string ConstructArguments()
        {
            string options = string.Empty;

            foreach (var option in _downloadOptionsList.Options)
            {
                options += $" --{option.Key}";
            }

            return options;
        }
    }
}

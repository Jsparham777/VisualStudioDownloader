using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class FileHandler : IFileHandler
    {
        private readonly IOptions<AppSettings> _options;
        private readonly string _argumentsFile = "Bootstrapper_Arguments.txt";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">Application settings.</param>
        public FileHandler(IOptions<AppSettings> options)
        {
            _options = options;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public string Read()
        {
            try
            {
                return File.ReadAllText(BuildArgumentsFilePath());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="content"><inheritdoc/></param>
        public void Write(string content)
        {
            try
            {
                File.WriteAllText(BuildArgumentsFilePath(), content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Builds the arguments file path.
        /// </summary>
        /// <returns>The path to the arguments file.</returns>
        private string BuildArgumentsFilePath()
        {
            string targetDir = Path.GetDirectoryName(_options.Value.BootstrapperPath);
            string argumentsFilePath = @$"{targetDir}\{_argumentsFile}";
            return argumentsFilePath;
        }
    }
}

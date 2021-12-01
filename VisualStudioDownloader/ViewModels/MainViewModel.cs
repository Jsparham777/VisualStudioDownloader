using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Main page view model.
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class MainViewModel : BaseViewModel
    {
        private readonly IOptions<AppSettings> _options;
        private string _downloadDirectory;
        private bool _bootstrapperFound;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel(IOptions<AppSettings> options)
        {
            _options = options;
            _downloadDirectory = Path.GetFullPath(_options.Value.BootstrapperPath);

            // Determine if the path is valid
            _bootstrapperFound = Directory.Exists(_downloadDirectory);           
        }

        /// <summary>
        /// Gets or sets the bootstrapper directory.
        /// </summary>
        public string DownloadDirectory
        {
            get => _downloadDirectory;
            set
            {
                _downloadDirectory = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the bootstrapper found flag.
        /// </summary>
        public bool BoostrapperFound
        {
            get => _bootstrapperFound;
            set
            {
                _bootstrapperFound = value;
                NotifyPropertyChanged();
            }
        }
    }
}

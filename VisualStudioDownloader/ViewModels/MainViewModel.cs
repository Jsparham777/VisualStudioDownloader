using Microsoft.Extensions.Options;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel(IOptions<AppSettings> options)
        {
            _options = options;
            _downloadDirectory = Path.GetDirectoryName(_options.Value.BootstrapperPath);
        }

        /// <summary>
        /// Gets or sets the the arguments file found flag.
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
    }
}

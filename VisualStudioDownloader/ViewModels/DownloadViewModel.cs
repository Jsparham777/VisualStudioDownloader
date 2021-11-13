using VisualStudioDownloader.Commands;
using VisualStudioDownloader.Models;
using VisualStudioDownloader.Services;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Download page view model.
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class DownloadViewModel : BaseViewModel
    {
        private IDownloadOptionsList _downloadOptionsList;
        private readonly IBootstrapperService _bootstrapperService;
        private BootstrapperInfo _bootstrapperIdentity;
        private bool _optionalComponents;
        private bool _recommendedComponents;

        /// <summary>
        /// Gets or sets the bootstrapper file information.
        /// </summary>
        public BootstrapperInfo BootstrapperIdentity
        {
            get => _bootstrapperIdentity;
            set
            {
                _bootstrapperIdentity = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the optional components option.
        /// </summary>
        public bool OptionalComponents
        {
            get => _optionalComponents;
            set
            {
                _optionalComponents = value;
                UpdateOption("includeOptional", value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the recommended components option.
        /// </summary>
        public bool RecommendedComponents
        {
            get => _recommendedComponents;
            set
            {
                _recommendedComponents = value;
                UpdateOption("IncludeRecommended", value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Triggers the bootstrapper identification.
        /// </summary>
        public RelayCommand IdentifyBootstrapper { get { return new RelayCommand((x) => PerformIdentifyBootstrapper()); } }

        /// <summary>
        /// Identifies the bootstrapper.
        /// </summary>
        private void PerformIdentifyBootstrapper()
        {
            var file = _bootstrapperService.IdentifyBootstrapper();
            BootstrapperIdentity = file;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="downloadOptionsList">The options list.</param>
        public DownloadViewModel(IDownloadOptionsList downloadOptionsList, IBootstrapperService bootstrapperService)
        {
            _downloadOptionsList = downloadOptionsList;
            _bootstrapperService = bootstrapperService;

            _downloadOptionsList.Clear();
        }

        /// <summary>
        /// Updates or adds an option to the options list.
        /// </summary>
        /// <param name="option">The option to update or add to the list.</param>
        /// <param name="value">The option value.</param>
        private void UpdateOption(string option, bool value)
        {
            // Add the option if it doesnt exist
            if (!_downloadOptionsList.Options.ContainsKey(option))
            {
                _downloadOptionsList.Options.Add(option, value);
                return;
            }

            // Update the option if it does exist
            _downloadOptionsList.Options[option] = value;
        }

        /// <summary>
        /// Triggers the download.
        /// </summary>
        public void Download()
        {
            _bootstrapperService.Download();
        }
    }
}
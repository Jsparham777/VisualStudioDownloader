using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using VisualStudioDownloader.Commands;
using VisualStudioDownloader.Services;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Zip page view model.
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class ZipViewModel : BaseViewModel
    {
        private readonly IBootstrapperService _bootstrapperService;
        private readonly IZippingService _zippingService;
        private List<string> _layoutContents;
        private string _outputPath;
        private int _selectedSplitSizeInMegaBytes;
        
        /// <summary>
        /// Gets or sets the layout folder contents.
        /// </summary>
        public List<string> LayoutContents
        {
            get => _layoutContents;
            set
            {
                _layoutContents = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the zip output path.
        /// </summary>
        public string OutputPath
        {
            get => _outputPath;
            set
            {
                _outputPath = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the possible zip split sizes in MBs.
        /// </summary>
        public ObservableCollection<int> SplitSizeInMegaBytes { get; set; } = new ObservableCollection<int> { 1024, 2048, 3072 };

        /// <summary>
        /// Gets or sets the selected zip split size in MBs.
        /// </summary>
        public int SelectedSplitSizeInMegaBytes
        {
            get => _selectedSplitSizeInMegaBytes;
            set
            {
                _selectedSplitSizeInMegaBytes = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Triggers the loading of the layout folder.
        /// </summary>
        public RelayCommand LoadLayoutFolder { get { return new RelayCommand((x) => PerformLoadLayoutFolder()); } }

        /// <summary>
        /// Loads the layout folder.
        /// </summary>
        private void PerformLoadLayoutFolder()
        {
            var dirInfo = new DirectoryInfo(Path.GetDirectoryName(_bootstrapperService.IdentifyBootstrapper().FilePath));

            var directories = dirInfo.GetDirectories().Select(x => x.Name).ToList();
            var files = dirInfo.GetFiles().Select(x => x.Name).ToList();

            directories.AddRange(files);

            LayoutContents = directories;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bootstrapperService">The bootstrapper service.</param>
        public ZipViewModel(IBootstrapperService bootstrapperService, IZippingService zippingService)
        {
            _bootstrapperService = bootstrapperService;
            _zippingService = zippingService;
        }

        /// <summary>
        /// Triggers the zip.
        /// </summary>
        public void Zip()
        {
            //TODO:
            // Add browse button
            // Add TextBox Style from resource dictionary

            var layoutPath = _bootstrapperService.IdentifyBootstrapper().FilePath;

            _zippingService.ZipDirectory(layoutPath, OutputPath, SelectedSplitSizeInMegaBytes);
        }
    }
}

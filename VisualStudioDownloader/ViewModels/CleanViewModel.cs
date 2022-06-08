using System.Collections.Generic;
using System.Linq;
using VisualStudioDownloader.Commands;
using VisualStudioDownloader.Services;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Clean page view model.
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class CleanViewModel : BaseViewModel
    {
        private readonly IBootstrapperService _bootstrapperService;
        private bool _archiveFoldersFound;
        private List<string> _archiveFolders;

        /// <summary>
        /// Gets or sets the the archive folders found flag.
        /// </summary>
        public bool ArchiveFoldersFound
        {
            get => _archiveFoldersFound;
            set
            {
                _archiveFoldersFound = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Archive folders.
        /// </summary>
        public List<string> ArchiveFolders
        {
            get => _archiveFolders;
            set
            {
                _archiveFolders = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Triggers the loading of the Archive folders.
        /// </summary>
        public RelayCommand LoadArchiveFolders { get { return new RelayCommand((x) => PerformLoadArchiveFolders()); } }

        /// <summary>
        /// Loads the Archive folders.
        /// </summary>
        private void PerformLoadArchiveFolders()
        {
            ArchiveFolders = _bootstrapperService.GetArchiveFolderContents().Select(x => x.Split(@"\").Last()).ToList();

            if (ArchiveFolders.Count > 0)
                ArchiveFoldersFound = true;     
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bootstrapperService">The bootstrapper service.</param>
        public CleanViewModel(IBootstrapperService bootstrapperService)
        {
            _bootstrapperService = bootstrapperService;
        }

        /// <summary>
        /// Triggers the clean.
        /// </summary>
        public void Clean()
        {
            _bootstrapperService.Clean();
        }
    }
}

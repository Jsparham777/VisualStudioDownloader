using System.Collections.Generic;
using System.Linq;
using VisualStudioDownloader.Commands;
using VisualStudioDownloader.Services;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Update page view model.
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class UpdateViewModel : BaseViewModel
    {
        private readonly IBootstrapperService _bootstrapperService;
        private bool _argumentsFileFound;
        private List<string> _arguments;

        /// <summary>
        /// Gets or sets the the arguments file found flag.
        /// </summary>
        public bool ArgumentsFileFound
        {
            get => _argumentsFileFound;
            set
            {
                _argumentsFileFound = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        public List<string> Arguments
        {
            get => _arguments;
            set
            {
                _arguments = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Triggers the loading of bootstrapper arguments.
        /// </summary>
        public RelayCommand LoadBootstrapperArguments { get { return new RelayCommand((x) => PerformLoadBootstrapperArguments()); } }

        /// <summary>
        /// Loads the bootstrapper arguments.
        /// </summary>
        private void PerformLoadBootstrapperArguments()
        {
            var args = _bootstrapperService.BuildArguments().Split("--").Skip(2).ToList();
            Arguments = args;

            if (Arguments.Count > 0)
                ArgumentsFileFound = true;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bootstrapperService">The bootstrapper service.</param>
        public UpdateViewModel(IBootstrapperService bootstrapperService)
        {
            _bootstrapperService = bootstrapperService;
        }

        /// <summary>
        /// Triggers the update.
        /// </summary>
        public void Update()
        {
            _bootstrapperService.Update();
        }
    }
}
